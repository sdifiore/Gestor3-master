using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class PreFormasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PreFormas
        public ActionResult Index(int? page)
        {
            var preFormas = db.PreFormas
                .Include(p => p.Extrusora)
                .Include(p => p.PrensaPreForma)
                .OrderBy(p => p.PreFormaNum);

            var pageNumber = page ?? 1;
            var onePageHistory = preFormas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PreFormas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var preForma = db.PreFormas
                .Include(p => p.Extrusora)
                .Include(p => p.PrensaPreForma)
                .SingleOrDefault(p => p.Id == id);

            if (preForma == null)
            {
                return HttpNotFound();
            }
            return View(preForma);
        }

        // GET: PreFormas/Create
        public ActionResult Create()
        {
            ViewBag.ExtrusoraId = new SelectList(db.Extrusoras, "Id", "Apelido");
            ViewBag.PrensaPreFormaId = new SelectList(db.PrensasPreForma, "Id", "Apelido");
            return View();
        }

        // POST: PreFormas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PreFormaNum,FormaDiamE,VaretaDiamI,Medidas,Comprimento,Tup,PrensaPreFormaId,Preparo,TrocaPf,ExtrusoraId,SecaoPf,KgfPrensagem,PressaoOleo,DiamPistaoHidraulico,KgPfUmida")] PreForma preForma)
        {
            if (ModelState.IsValid)
            {
                db.PreFormas.Add(preForma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExtrusoraId = new SelectList(db.Extrusoras, "Id", "Apelido", preForma.ExtrusoraId);
            ViewBag.PrensaPreFormaId = new SelectList(db.PrensasPreForma, "Id", "Apelido", preForma.PrensaPreFormaId);
            return View(preForma);
        }

        // GET: PreFormas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreForma preForma = db.PreFormas.Find(id);
            if (preForma == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExtrusoraId = new SelectList(db.Extrusoras, "Id", "Apelido", preForma.ExtrusoraId);
            ViewBag.PrensaPreFormaId = new SelectList(db.PrensasPreForma, "Id", "Apelido", preForma.PrensaPreFormaId);
            return View(preForma);
        }

        // POST: PreFormas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PreFormaNum,FormaDiamE,VaretaDiamI,Medidas,Comprimento,Tup,PrensaPreFormaId,Preparo,TrocaPf,ExtrusoraId,SecaoPf,KgfPrensagem,PressaoOleo,DiamPistaoHidraulico,KgPfUmida")] PreForma preForma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preForma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExtrusoraId = new SelectList(db.Extrusoras, "Id", "Apelido", preForma.ExtrusoraId);
            ViewBag.PrensaPreFormaId = new SelectList(db.PrensasPreForma, "Id", "Apelido", preForma.PrensaPreFormaId);
            return View(preForma);
        }

        // GET: PreFormas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var preForma = db.PreFormas
                .Include(p => p.Extrusora)
                .Include(p => p.PrensaPreForma)
                .SingleOrDefault(p => p.Id == id);

            if (preForma == null)
            {
                return HttpNotFound();
            }
            return View(preForma);
        }

        // POST: PreFormas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreForma preForma = db.PreFormas.Find(id);
            db.PreFormas.Remove(preForma);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var preForma = db.PreFormas
                .Include(p => p.Extrusora)
                .Include(p => p.PrensaPreForma)
                .SingleOrDefault(p => p.PreFormaNum.ToString() == search);

            if (preForma == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo preForma {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", preForma);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
