using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("PlanejProducao")]
    public class PlanejProducaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanejProducaos
        [Route]
        public ActionResult Index(int? page)
        {
            var planejProducoes = db.PlanejProducoes
                .Include(p => p.Produto)
                .Include(p => p.Produto.Categoria)
                .Include(p => p.Produto.Familia)
                .Include(p => p.Produto.Linha)
                .Include(p => p.Produto.Unidade)
                .OrderBy(p => p.Produto.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = planejProducoes.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PlanejProducaos/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlanejProducao planejProducao = db.PlanejProducoes
                .Include(p => p.Produto)
                .Include(p => p.Produto.Categoria)
                .Include(p => p.Produto.Familia)
                .Include(p => p.Produto.Linha)
                .Include(p => p.Produto.Unidade)
                .SingleOrDefault(p => p.Id == id);

            if (planejProducao == null)
            {
                return HttpNotFound();
            }
            return View(planejProducao);
        }

        // GET: PlanejProducaos/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            return View();
        }

        // POST: PlanejProducaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,VendaMesMenos11,VendaMesMenos10,VendaMesMenos09,VendaMesMenos08,VendaMesMenos07,VendaMesMenos06,VendaMesMenos05,VendaMesMenos04,VendaMesMenos03,VendaMesMenos02,VendaMesMenos01,VendaMesMenos00,PmpAnoMenos11,PmpAnoMenos10,PmpAnoMenos09,PmpAnoMenos08,PmpAnoMenos07,PmpAnoMenos06,PmpAnoMenos05,PmpAnoMenos04,PmpAnoMenos03,PmpAnoMenos02,PmpAnoMenos01,PmpAnoMenos00,SfmAnoMenos11,SfmAnoMenos10,SfmAnoMenos09,SfmAnoMenos08,SfmAnoMenos07,SfmAnoMenos06,SfmAnoMenos05,SfmAnoMenos04,SfmAnoMenos03,SfmAnoMenos02,SfmAnoMenos01,SfmAnoMenos00")] PlanejProducao planejProducao)
        {
            if (ModelState.IsValid)
            {
                db.PlanejProducoes.Add(planejProducao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", planejProducao.ProdutoId);
            return View(planejProducao);
        }

        // GET: PlanejProducaos/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanejProducao planejProducao = db.PlanejProducoes.Find(id);
            if (planejProducao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", planejProducao.ProdutoId);
            return View(planejProducao);
        }

        // POST: PlanejProducaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,VendaMesMenos11,VendaMesMenos10,VendaMesMenos09,VendaMesMenos08,VendaMesMenos07,VendaMesMenos06,VendaMesMenos05,VendaMesMenos04,VendaMesMenos03,VendaMesMenos02,VendaMesMenos01,VendaMesMenos00,PmpAnoMenos11,PmpAnoMenos10,PmpAnoMenos09,PmpAnoMenos08,PmpAnoMenos07,PmpAnoMenos06,PmpAnoMenos05,PmpAnoMenos04,PmpAnoMenos03,PmpAnoMenos02,PmpAnoMenos01,PmpAnoMenos00,SfmAnoMenos11,SfmAnoMenos10,SfmAnoMenos09,SfmAnoMenos08,SfmAnoMenos07,SfmAnoMenos06,SfmAnoMenos05,SfmAnoMenos04,SfmAnoMenos03,SfmAnoMenos02,SfmAnoMenos01,SfmAnoMenos00")] PlanejProducao planejProducao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planejProducao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", planejProducao.ProdutoId);
            return View(planejProducao);
        }

        // GET: PlanejProducaos/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlanejProducao planejProducao = db.PlanejProducoes
                .Include(p => p.Produto)
                .Include(p => p.Produto.Categoria)
                .Include(p => p.Produto.Familia)
                .Include(p => p.Produto.Linha)
                .Include(p => p.Produto.Unidade)
                .SingleOrDefault(p => p.Id == id);

            if (planejProducao == null)
            {
                return HttpNotFound();
            }
            return View(planejProducao);
        }

        // POST: PlanejProducaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanejProducao planejProducao = db.PlanejProducoes.Find(id);
            db.PlanejProducoes.Remove(planejProducao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var planejProducao = db.PlanejProducoes
                .Include(p => p.Produto)
                .Include(p => p.Produto.Categoria)
                .Include(p => p.Produto.Familia)
                .Include(p => p.Produto.Linha)
                .Include(p => p.Produto.Unidade)
                .SingleOrDefault(p => p.Produto.Apelido == search);

            if (planejProducao == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo insumo {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", planejProducao);
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
