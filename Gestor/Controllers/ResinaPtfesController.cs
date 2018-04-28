using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("ResinaPtfe")]
    public class ResinaPtfesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResinaPtfes
        [Route]
        public ActionResult Index(int? page)
        {
            var resinasPtfe = db.ResinasPtfe
                .Include(r => r.Fabricante)
                .Include(r => r.Insumo)
                .Include(r => r.ResinaBase)
                .OrderBy(r => r.Ref);

            var pageNumber = page ?? 1;
            var onePageHistory = resinasPtfe.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: ResinaPtfes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var resinaPtfe = db.ResinasPtfe
                .Include(r => r.Fabricante)
                .Include(r => r.Insumo)
                .Include(r => r.ResinaBase)
                .SingleOrDefault(r => r.Id == id);

            if (resinaPtfe == null)
            {
                return HttpNotFound();
            }
            return View(resinaPtfe);
        }

        // GET: ResinaPtfes/Create
        public ActionResult Create()
        {
            ViewBag.FabricanteId = new SelectList(db.Fabricantes, "Id", "Apelido");
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido");
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido");
            return View();
        }

        // POST: ResinaPtfes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ref,Referencia,FabricanteId,ResinaBaseId,InsumoId,Custo,MaxRr,Classificacao,MaxRrAntiga")] ResinaPtfe resinaPtfe)
        {
            if (ModelState.IsValid)
            {
                db.ResinasPtfe.Add(resinaPtfe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteId = new SelectList(db.Fabricantes, "Id", "Apelido", resinaPtfe.FabricanteId);
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", resinaPtfe.InsumoId);
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido", resinaPtfe.ResinaBaseId);
            return View(resinaPtfe);
        }

        // GET: ResinaPtfes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResinaPtfe resinaPtfe = db.ResinasPtfe.Find(id);
            if (resinaPtfe == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteId = new SelectList(db.Fabricantes, "Id", "Apelido", resinaPtfe.FabricanteId);
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", resinaPtfe.InsumoId);
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido", resinaPtfe.ResinaBaseId);
            return View(resinaPtfe);
        }

        // POST: ResinaPtfes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ref,Referencia,FabricanteId,ResinaBaseId,InsumoId,Custo,MaxRr,Classificacao,MaxRrAntiga")] ResinaPtfe resinaPtfe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resinaPtfe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteId = new SelectList(db.Fabricantes, "Id", "Apelido", resinaPtfe.FabricanteId);
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", resinaPtfe.InsumoId);
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido", resinaPtfe.ResinaBaseId);
            return View(resinaPtfe);
        }

        // GET: ResinaPtfes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var resinaPtfe = db.ResinasPtfe
                .Include(r => r.Fabricante)
                .Include(r => r.Insumo)
                .Include(r => r.ResinaBase)
                .SingleOrDefault(r => r.Id == id);

            if (resinaPtfe == null)
            {
                return HttpNotFound();
            }
            return View(resinaPtfe);
        }

        // POST: ResinaPtfes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResinaPtfe resinaPtfe = db.ResinasPtfe.Find(id);
            db.ResinasPtfe.Remove(resinaPtfe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(string search)
        {
            var resinaPtfe = db.ResinasPtfe
                .Include(r => r.Fabricante)
                .Include(r => r.Insumo)
                .Include(r => r.ResinaBase)
                .SingleOrDefault(r => r.Referencia.ToLower() == search.ToLower());

            if (resinaPtfe == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo resinaPtfe {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }
            return View("Details", resinaPtfe);
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
