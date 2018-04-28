using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;

namespace Gestor.Controllers
{
    public class DfxProdRevsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DfxProdRevs
        public ActionResult Index()
        {
            var dfxProdRevs = db.DfxProdRevs
                .Include(d => d.Produto)
                .Include(d => d.Unidade)
                .OrderBy(d => d.Produto.Apelido);

            return View(dfxProdRevs.ToList());
        }

        // GET: DfxProdRevs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dfxProdRev = db.DfxProdRevs
                .Include(d => d.Produto)
                .Include(d => d.Unidade)
                .SingleOrDefault(d => d.Id == id);

            if (dfxProdRev == null)
            {
                return HttpNotFound();
            }
            return View(dfxProdRev);
        }

        // GET: DfxProdRevs/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido");
            return View();
        }

        // POST: DfxProdRevs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,UnidadeId,QtdUnidade,QtdCompra,PrecoCompra,ValorCompra,RateioDfixProduto,RateioDfixUnidade,MoiFabrica,DespsFabrica,DespsDepComercial,DespsDeptAdminLog,QtdRolos,RateioDfixProdutoUnitario,ProporcaoCusto,ProporcaoEmCxs")] DfxProdRev dfxProdRev)
        {
            if (ModelState.IsValid)
            {
                db.DfxProdRevs.Add(dfxProdRev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", dfxProdRev.ProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", dfxProdRev.UnidadeId);
            return View(dfxProdRev);
        }

        // GET: DfxProdRevs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DfxProdRev dfxProdRev = db.DfxProdRevs.Find(id);
            if (dfxProdRev == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", dfxProdRev.ProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", dfxProdRev.UnidadeId);
            return View(dfxProdRev);
        }

        // POST: DfxProdRevs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,UnidadeId,QtdUnidade,QtdCompra,PrecoCompra,ValorCompra,RateioDfixProduto,RateioDfixUnidade,MoiFabrica,DespsFabrica,DespsDepComercial,DespsDeptAdminLog,QtdRolos,RateioDfixProdutoUnitario,ProporcaoCusto,ProporcaoEmCxs")] DfxProdRev dfxProdRev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dfxProdRev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", dfxProdRev.ProdutoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", dfxProdRev.UnidadeId);
            return View(dfxProdRev);
        }

        // GET: DfxProdRevs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dfxProdRev = db.DfxProdRevs
                .Include(d => d.Produto)
                .Include(d => d.Unidade)
                .SingleOrDefault(d => d.Id == id);

            if (dfxProdRev == null)
            {
                return HttpNotFound();
            }
            return View(dfxProdRev);
        }

        // POST: DfxProdRevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DfxProdRev dfxProdRev = db.DfxProdRevs.Find(id);
            db.DfxProdRevs.Remove(dfxProdRev);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var dfxProdRev = db.DfxProdRevs
                .Include(d => d.Produto)
                .Include(d => d.Unidade)
                .SingleOrDefault(d => d.Produto.Apelido == search);

            if (dfxProdRev == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo dfxProdRev {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", dfxProdRev);
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
