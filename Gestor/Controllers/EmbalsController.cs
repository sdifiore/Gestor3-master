using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class EmbalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Embals
        public ActionResult Index(int? page)
        {
            var embals = db.Embals
                        .Include(e => e.Insumo)
                        .OrderBy(e => e.Insumo.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = embals.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Embals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Embal embal = db.Embals
                .Include(e => e.Insumo)
                .SingleOrDefault(e => e.Id == id);

            if (embal == null)
            {
                return HttpNotFound();
            }
            return View(embal);
        }

        // GET: Embals/Create
        public ActionResult Create()
        {
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido");
            return View();
        }

        // POST: Embals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sigla,InsumoId")] Embal embal)
        {
            if (ModelState.IsValid)
            {
                db.Embals.Add(embal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", embal.InsumoId);
            return View(embal);
        }

        // GET: Embals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embal embal = db.Embals.Find(id);
            if (embal == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", embal.InsumoId);
            return View(embal);
        }

        // POST: Embals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sigla,InsumoId")] Embal embal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(embal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", embal.InsumoId);
            return View(embal);
        }

        // GET: Embals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Embal embal = db.Embals
                .Include(e => e.Insumo)
                .SingleOrDefault(e => e.Id == id);

            if (embal == null)
            {
                return HttpNotFound();
            }
            return View(embal);
        }

        // POST: Embals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Embal embal = db.Embals.Find(id);
            db.Embals.Remove(embal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Embals
                        .Include(e => e.Insumo)
                .SingleOrDefault(g => g.Sigla == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura por Embalagem {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", model);
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
