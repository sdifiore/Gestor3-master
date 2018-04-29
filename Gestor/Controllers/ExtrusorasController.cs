using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class ExtrusorasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Extrusoras
        public ActionResult Index(int? page)
        {
            var model = db.Extrusoras
                .OrderBy(e => e.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Extrusoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extrusora extrusora = db.Extrusoras.Find(id);
            if (extrusora == null)
            {
                return HttpNotFound();
            }
            return View(extrusora);
        }

        // GET: Extrusoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extrusoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apelido,Descricao")] Extrusora extrusora)
        {
            if (ModelState.IsValid)
            {
                db.Extrusoras.Add(extrusora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extrusora);
        }

        // GET: Extrusoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extrusora extrusora = db.Extrusoras.Find(id);
            if (extrusora == null)
            {
                return HttpNotFound();
            }
            return View(extrusora);
        }

        // POST: Extrusoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Descricao")] Extrusora extrusora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extrusora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extrusora);
        }

        // GET: Extrusoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extrusora extrusora = db.Extrusoras.Find(id);
            if (extrusora == null)
            {
                return HttpNotFound();
            }
            return View(extrusora);
        }

        // POST: Extrusoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Extrusora extrusora = db.Extrusoras.Find(id);
            return View("Erase", extrusora);
        }

        // POST: Extrusoras/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Extrusora extrusora = db.Extrusoras.Find(id);
            db.Extrusoras.Remove(extrusora);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Extrusoras
                .SingleOrDefault(g => g.Apelido.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela extrusora {search} não produziu resultado");
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
