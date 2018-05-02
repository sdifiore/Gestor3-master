using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class PlanejComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanejCompras
        public ActionResult Index(int? page)
        {
            var planejCompras = db.PlanejCompras
                .Include(p => p.Insumo)
                .Include(p => p.Unidade)
                .Include(p => p.Insumo.Categoria)
                .OrderBy(p => p.Insumo.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = planejCompras.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PlanejCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var planejCompra = db.PlanejCompras
                .Include(p => p.Insumo)
                .Include(p => p.Unidade)
                .Include(p => p.Insumo.Categoria)
                .SingleOrDefault(p => p.Id == id);

            if (planejCompra == null)
            {
                return HttpNotFound();
            }
            return View(planejCompra);
        }

        // GET: PlanejCompras/Create
        public ActionResult Create()
        {
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido");
            return View();
        }

        // POST: PlanejCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InsumoId,SomaDe1,SomaDe2,SomaDe3,SomaDe4,SomaDe5,SomaDe6,SomaDe7,SomaDe8,SomaDe9,SomaDe10,SomaDe11,SomaDe12,UnidadeId,FatorConsumo,LoteCompra,EstoqueMinimo,PrecoUnitarioBruto,CustoUnitario,CreditoUnitIcms,CreditoUnitIpi,CreditoUnitPis,CreditoUnitCofins,PagFornecImport,IiDespImport,MesRefPag1Fornec,MesRefPag2Fornec,EstoqueInicial,NCMPAnoMenos11,NCMPAnoMenos10,NCMPAnoMenos9,NCMPAnoMenos8,NCMPAnoMenos7,NCMPAnoMenos6,NCMPAnoMenos5,NCMPAnoMenos4,NCMPAnoMenos3,NCMPAnoMenos2,NCMPAnoMenos1,NCMPAno,QCMes1,QCMes2,QCMes3,QCMes4,QCMes5,QCMes6,QCMes7,QCMes8,QCMes9,QCMes10,QCMes11,QCMes12,SFCMAnoMenos11,SFCMAnoMenos10,SFCMAnoMenos9,SFCMAnoMenos8,SFCMAnoMenos7,SFCMAnoMenos6,SFCMAnoMenos5,SFCMAnoMenos4,SFCMAnoMenos3,SFCMAnoMenos2,SFCMAnoMenos1,SFCMAno,VBCMes1,VBCMes2,VBCMes3,VBCMes4,VBCMes5,VBCMes6,VBCMes7,VBCMes8,VBCMes9,VBCMes10,VBCMes11,VBCMes12,PFNMes1,PFNMes2,PFNMes3,PFNMes4,PFNMes5,PFNMes6,PFNMes7,PFNMes8,PFNMes9,PFNMes10,PFNMes11,PFNMes12,PFIMes1,PFIMes2,PFIMes3,PFIMes4,PFIMes5,PFIMes6,PFIMes7,PFIMes8,PFIMes9,PFIMes10,PFIMes11,PFIMes12,PIIDIMes1,PIIDIMes2,PIIDIMes3,PIIDIMes4,PIIDIMes5,PIIDIMes6,PIIDIMes7,PIIDIMes8,PIIDIMes9,PIIDIMes10,PIIDIMes11,PIIDIMes12,VCCMes1,VCCMes2,VCCMes3,VCCMes4,VCCMes5,VCCMes6,VCCMes7,VCCMes8,VCCMes9,VCCMes10,VCCMes11,VCCMes12,VCIcmsMes1,VCIcmsMes2,VCIcmsMes3,VCIcmsMes4,VCIcmsMes5,VCIcmsMes6,VCIcmsMes7,VCIcmsMes8,VCIcmsMes9,VCIcmsMes10,VCIcmsMes11,VCIcmsMes12,VCIpiMes1,VCIpiMes2,VCIpiMes3,VCIpiMes4,VCIpiMes5,VCIpiMes6,VCIpiMes7,VCIpiMes8,VCIpiMes9,VCIpiMes10,VCIpiMes11,VCIpiMes12,CPisCofinsMes1,CPisCofinsMes2,CPisCofinsMes3,CPisCofinsMes4,CPisCofinsMes5,CPisCofinsMes6,CPisCofinsMes7,CPisCofinsMes8,CPisCofinsMes9,CPisCofinsMes10,CPisCofinsMes11,CPisCofinsMes12,MediaMensal")] PlanejCompra planejCompra)
        {
            if (ModelState.IsValid)
            {
                db.PlanejCompras.Add(planejCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", planejCompra.InsumoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", planejCompra.UnidadeId);
            return View(planejCompra);
        }

        // GET: PlanejCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var planejCompra = db.PlanejCompras
                .Include(p => p.Insumo)
                .Include(p => p.Unidade)
                .Include(p => p.Insumo.Categoria)
                .SingleOrDefault(p => p.Id == id);

            if (planejCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", planejCompra.InsumoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", planejCompra.UnidadeId);
            return View(planejCompra);
        }

        // POST: PlanejCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InsumoId,SomaDe1,SomaDe2,SomaDe3,SomaDe4,SomaDe5,SomaDe6,SomaDe7,SomaDe8,SomaDe9,SomaDe10,SomaDe11,SomaDe12,UnidadeId,FatorConsumo,LoteCompra,EstoqueMinimo,PrecoUnitarioBruto,CustoUnitario,CreditoUnitIcms,CreditoUnitIpi,CreditoUnitPis,CreditoUnitCofins,PagFornecImport,IiDespImport,MesRefPag1Fornec,MesRefPag2Fornec,EstoqueInicial,NCMPAnoMenos11,NCMPAnoMenos10,NCMPAnoMenos9,NCMPAnoMenos8,NCMPAnoMenos7,NCMPAnoMenos6,NCMPAnoMenos5,NCMPAnoMenos4,NCMPAnoMenos3,NCMPAnoMenos2,NCMPAnoMenos1,NCMPAno,QCMes1,QCMes2,QCMes3,QCMes4,QCMes5,QCMes6,QCMes7,QCMes8,QCMes9,QCMes10,QCMes11,QCMes12,SFCMAnoMenos11,SFCMAnoMenos10,SFCMAnoMenos9,SFCMAnoMenos8,SFCMAnoMenos7,SFCMAnoMenos6,SFCMAnoMenos5,SFCMAnoMenos4,SFCMAnoMenos3,SFCMAnoMenos2,SFCMAnoMenos1,SFCMAno,VBCMes1,VBCMes2,VBCMes3,VBCMes4,VBCMes5,VBCMes6,VBCMes7,VBCMes8,VBCMes9,VBCMes10,VBCMes11,VBCMes12,PFNMes1,PFNMes2,PFNMes3,PFNMes4,PFNMes5,PFNMes6,PFNMes7,PFNMes8,PFNMes9,PFNMes10,PFNMes11,PFNMes12,PFIMes1,PFIMes2,PFIMes3,PFIMes4,PFIMes5,PFIMes6,PFIMes7,PFIMes8,PFIMes9,PFIMes10,PFIMes11,PFIMes12,PIIDIMes1,PIIDIMes2,PIIDIMes3,PIIDIMes4,PIIDIMes5,PIIDIMes6,PIIDIMes7,PIIDIMes8,PIIDIMes9,PIIDIMes10,PIIDIMes11,PIIDIMes12,VCCMes1,VCCMes2,VCCMes3,VCCMes4,VCCMes5,VCCMes6,VCCMes7,VCCMes8,VCCMes9,VCCMes10,VCCMes11,VCCMes12,VCIcmsMes1,VCIcmsMes2,VCIcmsMes3,VCIcmsMes4,VCIcmsMes5,VCIcmsMes6,VCIcmsMes7,VCIcmsMes8,VCIcmsMes9,VCIcmsMes10,VCIcmsMes11,VCIcmsMes12,VCIpiMes1,VCIpiMes2,VCIpiMes3,VCIpiMes4,VCIpiMes5,VCIpiMes6,VCIpiMes7,VCIpiMes8,VCIpiMes9,VCIpiMes10,VCIpiMes11,VCIpiMes12,CPisCofinsMes1,CPisCofinsMes2,CPisCofinsMes3,CPisCofinsMes4,CPisCofinsMes5,CPisCofinsMes6,CPisCofinsMes7,CPisCofinsMes8,CPisCofinsMes9,CPisCofinsMes10,CPisCofinsMes11,CPisCofinsMes12,MediaMensal")] PlanejCompra planejCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planejCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsumoId = new SelectList(db.Insumos, "InsumoId", "Apelido", planejCompra.InsumoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", planejCompra.UnidadeId);
            return View(planejCompra);
        }

        // GET: PlanejCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var planejCompra = db.PlanejCompras
                .Include(p => p.Insumo)
                .Include(p => p.Unidade)
                .Include(p => p.Insumo.Categoria)
                .SingleOrDefault(p => p.Id == id);

            if (planejCompra == null)
            {
                return HttpNotFound();
            }
            return View(planejCompra);
        }

        // POST: PlanejCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var planejCompra = db.PlanejCompras
                .Include(p => p.Insumo)
                .Include(p => p.Unidade)
                .Include(p => p.Insumo.Categoria)
                .SingleOrDefault(p => p.Id == id);

            return View("Erase", planejCompra);
        }

        // POST: PlanejCompras/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            var planejCompra = db.PlanejCompras.Find(id);
            db.PlanejCompras.Remove(planejCompra);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var planejCompra = db.PlanejCompras
                .Include(p => p.Insumo)
                .Include(p => p.Unidade)
                .Include(p => p.Insumo.Categoria)
                .SingleOrDefault(i => i.Insumo.Apelido == search);

            if (planejCompra == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Planejamento de Compra {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", planejCompra);
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
