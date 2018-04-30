using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class PrensaPreFormasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PrensaPreFormas
        public ActionResult Index(int? page)
        {
            var model = db.PrensasPreForma
                .OrderBy(ppf => ppf.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PrensaPreFormas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrensaPreForma prensaPreForma = db.PrensasPreForma.Find(id);
            if (prensaPreForma == null)
            {
                return HttpNotFound();
            }
            return View(prensaPreForma);
        }

        // GET: PrensaPreFormas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrensaPreFormas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apelido,Descricao")] PrensaPreForma prensaPreForma)
        {
            if (ModelState.IsValid)
            {
                db.PrensasPreForma.Add(prensaPreForma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prensaPreForma);
        }

        // GET: PrensaPreFormas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrensaPreForma prensaPreForma = db.PrensasPreForma.Find(id);
            if (prensaPreForma == null)
            {
                return HttpNotFound();
            }
            return View(prensaPreForma);
        }

        // POST: PrensaPreFormas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Descricao")] PrensaPreForma prensaPreForma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prensaPreForma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prensaPreForma);
        }

        // GET: PrensaPreFormas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrensaPreForma prensaPreForma = db.PrensasPreForma.Find(id);
            if (prensaPreForma == null)
            {
                return HttpNotFound();
            }
            return View(prensaPreForma);
        }

        // POST: PrensaPreFormas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrensaPreForma prensaPreForma = db.PrensasPreForma.Find(id);
            return View("Erase", prensaPreForma);
        }

        // POST: PrensaPreFormas/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            PrensaPreForma prensaPreForma = db.PrensasPreForma.Find(id);
            db.PrensasPreForma.Remove(prensaPreForma);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.PrensasPreForma
                .SingleOrDefault(g => g.Apelido.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Prensa Preforma {search} não produziu resultado");
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
