using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class IndiceRateioLucratividadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IndiceRateioLucratividades
        public ActionResult Index(int? page)
        {
            var indiceRateioLucratividades = db.IndiceRateioLucratividades
                .Include(i => i.GrupoRateio)
                .OrderBy(i => i.GrupoRateio.Grupo);

            var pageNumber = page ?? 1;
            var onePageHistory = indiceRateioLucratividades.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: IndiceRateioLucratividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IndiceRateioLucratividade indiceRateioLucratividade = db.IndiceRateioLucratividades
                .Include(i => i.GrupoRateio)
                .SingleOrDefault(i => i.Id == id);

            if (indiceRateioLucratividade == null)
            {
                return HttpNotFound();
            }
            return View(indiceRateioLucratividade);
        }

        // GET: IndiceRateioLucratividades/Create
        public ActionResult Create()
        {
            ViewBag.GrupoRateioId = new SelectList(db.Rateios, "RateioId", "Grupo");
            return View();
        }

        // POST: IndiceRateioLucratividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RateioId,Grupo")] IndiceRateioLucratividade indiceRateioLucratividade)
        {
            if (ModelState.IsValid)
            {
                db.IndiceRateioLucratividades.Add(indiceRateioLucratividade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoRateioId = new SelectList(db.Rateios, "RateioId", "Grupo", indiceRateioLucratividade.GrupoRateioId);
            return View(indiceRateioLucratividade);
        }

        // GET: IndiceRateioLucratividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndiceRateioLucratividade indiceRateioLucratividade = db.IndiceRateioLucratividades.Find(id);
            if (indiceRateioLucratividade == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoRateioId = new SelectList(db.Rateios, "RateioId", "Grupo", indiceRateioLucratividade.GrupoRateioId);
            return View(indiceRateioLucratividade);
        }

        // POST: IndiceRateioLucratividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RateioId,Grupo")] IndiceRateioLucratividade indiceRateioLucratividade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indiceRateioLucratividade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoRateioId = new SelectList(db.Rateios, "RateioId", "Grupo", indiceRateioLucratividade.GrupoRateioId);
            return View(indiceRateioLucratividade);
        }

        // GET: IndiceRateioLucratividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IndiceRateioLucratividade indiceRateioLucratividade = db.IndiceRateioLucratividades
                .Include(i => i.GrupoRateio)
                .SingleOrDefault(i => i.Id == id);

            if (indiceRateioLucratividade == null)
            {
                return HttpNotFound();
            }
            return View(indiceRateioLucratividade);
        }

        // POST: IndiceRateioLucratividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndiceRateioLucratividade indiceRateioLucratividade = db.IndiceRateioLucratividades.Find(id);
            db.IndiceRateioLucratividades.Remove(indiceRateioLucratividade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var rateio = db.Rateios.SingleOrDefault(r => r.Grupo == search);

            if (rateio == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Rateio {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            var model = db.IndiceRateioLucratividades
                .Include(i => i.GrupoRateio)
                .SingleOrDefault(g => g.GrupoRateioId == rateio.RateioId);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Rateio {search} não produziu resultado");
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
