using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("EncapTubos")]
    public class EncapTuboesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EncapTuboes
        [Route]
        public ActionResult Index(int? page)
        {
            var encapTuboes = db.EncapTuboes
                .Include(e => e.Produto)
                .Include(e => e.Unidade)
                .OrderBy(e => e.Produto.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = encapTuboes.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: EncapTuboes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var encapTubo = db.EncapTuboes
                .Include(e => e.Produto)
                .Include(e => e.Unidade)
                .SingleOrDefault(e => e.Id == id);

            if (encapTubo == null)
            {
                return HttpNotFound();
            }
            return View(encapTubo);
        }

        // GET: EncapTuboes/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido");
            return View();
        }

        // POST: EncapTuboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,UnidadeId,DextRevest,ResinaBase,Aditivo,DenRev,PesoRevest,VelRevest,PctCarga,Resina,Master")] EncapTubo encapTubo)
        {
            if (ModelState.IsValid)
            {
                encapTubo.PctCarga = encapTubo.PctCarga / 100;
                db.EncapTuboes.Add(encapTubo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", encapTubo.ProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", encapTubo.UnidadeId);
            return View(encapTubo);
        }

        // GET: EncapTuboes/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncapTubo encapTubo = db.EncapTuboes.Find(id);
            if (encapTubo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", encapTubo.ProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", encapTubo.UnidadeId);
            return View(encapTubo);
        }

        // POST: EncapTuboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,UnidadeId,DextRevest,ResinaBase,Aditivo,DenRev,PesoRevest,VelRevest,PctCarga,Resina,Master")] EncapTubo encapTubo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encapTubo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", encapTubo.ProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", encapTubo.UnidadeId);
            return View(encapTubo);
        }

        // GET: EncapTuboes/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var encapTubo = db.EncapTuboes
                .Include(e => e.Produto)
                .Include(e => e.Unidade)
                .SingleOrDefault(e => e.Id == id);

            if (encapTubo == null)
            {
                return HttpNotFound();
            }
            return View(encapTubo);
        }

        // POST: EncapTuboes/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var encapTubo = db.EncapTuboes
                .Include(e => e.Produto)
                .Include(e => e.Unidade)
                .SingleOrDefault(e => e.Id == id);

            return View("Erase", encapTubo);
        }

        // POST: EncapTuboes/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            EncapTubo encapTubo = db.EncapTuboes.Find(id);
            db.EncapTuboes.Remove(encapTubo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var encapTubo = db.EncapTuboes
                .Include(e => e.Produto)
                .Include(e => e.Unidade)
                .SingleOrDefault(e => e.Produto.Apelido == search);

            if (encapTubo == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo insumo {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", encapTubo);
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
