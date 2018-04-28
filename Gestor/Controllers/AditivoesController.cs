using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("Aditivos")]
    public class AditivoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aditivoes
        [Route]
        public ActionResult Index(int? page)
        {
            var aditivos = db.Aditivos
                .Include(a => a.Carga)
                .Include(a => a.Insumo)
                .OrderBy(a => a.Carga.Apelido)
                .OrderBy(a => a.Carga.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = aditivos.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Aditivoes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var aditivo = db.Aditivos
                .Include(a => a.Carga)
                .Include(a => a.Insumo)
                .SingleOrDefault(a => a.Id == id);

            if (aditivo == null)
            {
                return HttpNotFound();
            }
            return View(aditivo);
        }

        // GET: Aditivoes/Create
        public ActionResult Create()
        {
            ViewBag.CargaId = new SelectList(db.Cargas, "Id", "Apelido");
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido");
            return View();
        }

        // POST: Aditivoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CargaId,InsumoId")] Aditivo aditivo)
        {
            if (ModelState.IsValid)
            {
                db.Aditivos.Add(aditivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargaId = new SelectList(db.Cargas, "Id", "Apelido", aditivo.CargaId);
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", aditivo.InsumoId);
            return View(aditivo);
        }

        // GET: Aditivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aditivo aditivo = db.Aditivos.Find(id);
            if (aditivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargaId = new SelectList(db.Cargas, "Id", "Apelido", aditivo.CargaId);
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", aditivo.InsumoId);
            return View(aditivo);
        }

        // POST: Aditivoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CargaId,InsumoId")] Aditivo aditivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aditivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargaId = new SelectList(db.Cargas, "Id", "Apelido", aditivo.CargaId);
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", aditivo.InsumoId);
            return View(aditivo);
        }

        // GET: Aditivoes/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var aditivo = db.Aditivos
                .Include(a => a.Carga)
                .Include(a => a.Insumo)
                .SingleOrDefault(a => a.Id == id);

            if (aditivo == null)
            {
                return HttpNotFound();
            }

            return View(aditivo);
        }

        // POST: Estruturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aditivo aditivo = db.Aditivos.Find(id);
            return View("Erase", aditivo);
        }

        // POST: Estruturas/Erase/5
        [HttpPost]
        [Route("Erase")]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Aditivo aditivo = db.Aditivos.Find(id);
            db.Aditivos.Remove(aditivo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(string search)
        {
            var aditivos = db.Aditivos
                .Include(a => a.Carga)
                .SingleOrDefault(a => a.Insumo.Apelido == search);

            if (aditivos == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo aditivo {search} não produziu Aditivos");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", aditivos);
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
