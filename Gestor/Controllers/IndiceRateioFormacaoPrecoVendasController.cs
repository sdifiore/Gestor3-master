using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class IndiceRateioFormacaoPrecoVendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IndiceRateioFormacaoPrecoVendas
        public ActionResult Index(int? page)
        {
            var indiceRateioFormacaoPrecoVendas = db.IndiceRateioFormacaoPrecoVendas
                .Include(i => i.GrupoRateio)
                .OrderBy(i => i.GrupoRateio.Grupo);

            var pageNumber = page ?? 1;
            var onePageHistory = indiceRateioFormacaoPrecoVendas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;
            ViewBag.Grupos = GrupoVector();

            return View();
        }

        private string[] GrupoVector()
        {
            var rateio = db.Rateios;
            int depth = rateio.Count();
            var grupo = new string[depth];
            int count = 0;

            foreach (var item in rateio)
            {
                grupo[count++] = item.Grupo;
            }

            return grupo;
        }

        // GET: IndiceRateioFormacaoPrecoVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IndiceRateioFormacaoPrecoVenda indiceRateioFormacaoPrecoVenda = db.IndiceRateioFormacaoPrecoVendas
                .Include(i => i.GrupoRateio)
                .SingleOrDefault(i => i.Id == id);

            if (indiceRateioFormacaoPrecoVenda == null)
            {
                return HttpNotFound();
            }
            return View(indiceRateioFormacaoPrecoVenda);
        }

        // GET: IndiceRateioFormacaoPrecoVendas/Create
        public ActionResult Create()
        {
            ViewBag.GrupoRateioId = new SelectList(db.Rateios, "RateioId", "Grupo");
            return View();
        }

        // POST: IndiceRateioFormacaoPrecoVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RateioId,Grupo")] IndiceRateioFormacaoPrecoVenda indiceRateioFormacaoPrecoVenda)
        {
            if (ModelState.IsValid)
            {
                db.IndiceRateioFormacaoPrecoVendas.Add(indiceRateioFormacaoPrecoVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoRateioId = new SelectList(db.Rateios, "RateioId", "Grupo", indiceRateioFormacaoPrecoVenda.GrupoRateioId);
            return View(indiceRateioFormacaoPrecoVenda);
        }

        // GET: IndiceRateioFormacaoPrecoVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndiceRateioFormacaoPrecoVenda indiceRateioFormacaoPrecoVenda = db.IndiceRateioFormacaoPrecoVendas.Find(id);
            if (indiceRateioFormacaoPrecoVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoRateioId = new SelectList(db.Rateios, "RateioId", "Grupo", indiceRateioFormacaoPrecoVenda.GrupoRateioId);
            return View(indiceRateioFormacaoPrecoVenda);
        }

        // POST: IndiceRateioFormacaoPrecoVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RateioId,Grupo")] IndiceRateioFormacaoPrecoVenda indiceRateioFormacaoPrecoVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indiceRateioFormacaoPrecoVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "RateioId", "Grupo", indiceRateioFormacaoPrecoVenda.GrupoRateioId);
            return View(indiceRateioFormacaoPrecoVenda);
        }

        // GET: IndiceRateioFormacaoPrecoVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IndiceRateioFormacaoPrecoVenda indiceRateioFormacaoPrecoVenda = db.IndiceRateioFormacaoPrecoVendas
                .Include(i => i.GrupoRateio)
                .SingleOrDefault(i => i.Id == id);

            if (indiceRateioFormacaoPrecoVenda == null)
            {
                return HttpNotFound();
            }

            ViewBag.Grupos = GrupoVector();

            return View(indiceRateioFormacaoPrecoVenda);
        }

        // POST: Familias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var indiceRateioFormacaoPrecoVenda = db.IndiceRateioFormacaoPrecoVendas.Find(id);
            ViewBag.Grupos = GrupoVector();

            return View("Erase", indiceRateioFormacaoPrecoVenda);
        }

        // POST: Familias/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            var indiceRateioFormacaoPrecoVenda = db.IndiceRateioFormacaoPrecoVendas.Find(id);
            db.IndiceRateioFormacaoPrecoVendas.Remove(indiceRateioFormacaoPrecoVenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var rateio = db.Rateios.SingleOrDefault(r => r.Grupo == search);

            if (rateio == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Indice de Formaç~cao de Preço de Venda {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            var model = db.IndiceRateioFormacaoPrecoVendas
                .Include(i => i.GrupoRateio)
                .SingleOrDefault(g => g.GrupoRateioId == rateio.RateioId);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Indice de Formaç~cao de Preço de Venda {search} não produziu resultado");
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
