using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class LubrificantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lubrificantes
        public ActionResult Index(int? page)
        {
            var lubrificantes = db.Lubrificantes
                .Include(l => l.Insumo)
                .OrderBy(l => l.Ref);

            var pageNumber = page ?? 1;
            var onePageHistory = lubrificantes.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Lubrificantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lubrificante lubrificante = db.Lubrificantes
                .Include(l => l.Insumo)
                .SingleOrDefault(l => l.Id == id);

            if (lubrificante == null)
            {
                return HttpNotFound();
            }
            return View(lubrificante);
        }

        // GET: Lubrificantes/Create
        public ActionResult Create()
        {
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido");
            return View();
        }

        // POST: Lubrificantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ref,Referencia,InsumoId")] Lubrificante lubrificante)
        {
            if (ModelState.IsValid)
            {
                db.Lubrificantes.Add(lubrificante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", lubrificante.InsumoId);
            return View(lubrificante);
        }

        // GET: Lubrificantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lubrificante lubrificante = db.Lubrificantes.Find(id);
            if (lubrificante == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", lubrificante.InsumoId);
            return View(lubrificante);
        }

        // POST: Lubrificantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ref,Referencia,InsumoId")] Lubrificante lubrificante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lubrificante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", lubrificante.InsumoId);
            return View(lubrificante);
        }

        // GET: Lubrificantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lubrificante lubrificante = db.Lubrificantes
                .Include(l => l.Insumo)
                .SingleOrDefault(l => l.Id == id);

            if (lubrificante == null)
            {
                return HttpNotFound();
            }
            return View(lubrificante);
        }

        // POST: Lubrificantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lubrificante lubrificante = db.Lubrificantes.Find(id);
            return View("Erase", lubrificante);
        }

        // POST: Lubrificantes/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Lubrificante lubrificante = db.Lubrificantes.Find(id);
            db.Lubrificantes.Remove(lubrificante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Lubrificantes
                .Include(l => l.Insumo)
                .SingleOrDefault(g => g.Ref == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo lubrificante {search} não produziu resultado");
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
