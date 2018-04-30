// Custo_3.PlanejVendas

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class MedidaFitasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedidaFitas
        public ActionResult Index(int? page)
        {
            var model = db.MedidaFitas
                .OrderBy(mf => mf.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: MedidaFitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidaFita medidaFita = db.MedidaFitas.Find(id);
            if (medidaFita == null)
            {
                return HttpNotFound();
            }
            return View(medidaFita);
        }

        // GET: MedidaFitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedidaFitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedidaFitaId,Apelido,LarguraMm,ComprimentoMetros")] MedidaFita medidaFita)
        {
            if (ModelState.IsValid)
            {
                db.MedidaFitas.Add(medidaFita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medidaFita);
        }

        // GET: MedidaFitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidaFita medidaFita = db.MedidaFitas.Find(id);
            if (medidaFita == null)
            {
                return HttpNotFound();
            }
            return View(medidaFita);
        }

        // POST: MedidaFitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedidaFitaId,Apelido,LarguraMm,ComprimentoMetros")] MedidaFita medidaFita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medidaFita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medidaFita);
        }

        // GET: MedidaFitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidaFita medidaFita = db.MedidaFitas.Find(id);
            if (medidaFita == null)
            {
                return HttpNotFound();
            }
            return View(medidaFita);
        }

        // POST: MedidaFitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedidaFita medidaFita = db.MedidaFitas.Find(id);
            return View("Erase", medidaFita);
        }

        // POST: MedidaFitas/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            MedidaFita medidaFita = db.MedidaFitas.Find(id);
            db.MedidaFitas.Remove(medidaFita);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.MedidaFitas
                .SingleOrDefault(g => g.Apelido == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela medida fita {search} não produziu resultado");
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
