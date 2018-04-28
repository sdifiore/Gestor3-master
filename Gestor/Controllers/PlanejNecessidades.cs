using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class PlanejNecessidadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanejNecessidades
        public ActionResult Index(int? page)
        {
            var estruturas = db.Estruturas
                .Include(e => e.Produto)
                .Include(e => e.Sequencia)
                .Include(e => e.Unidade)
                .Include(e => e.UnidadeCompra)
                .OrderBy(e => e.Produto.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = estruturas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PlanejNecessidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estrutura estrutura = db.Estruturas.Find(id);
            if (estrutura == null)
            {
                return HttpNotFound();
            }
            return View(estrutura);
        }

        // GET: PlanejNecessidades/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo");
            return View();
        }

        // POST: PlanejNecessidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,UnidadeId,QtdCusto,SequenciaId,Item,DescCompProc,UnidadeCompraId,CustoUnitCompra,Onera,Lote,Perda,Observacao,PartCusto,QtEftvUntrCmpnt,CstCmprUndPrd,TpItmCst,AlrtSbPrdt,TempMaq,QtdUndd,PsLiqdFnl,PsLiqdPrcdt,HrsModFnl,HrsModPrec1,HrsModPrec2,IdProd,IdCmpnt,PdrHoraria,ProdComp,CstIndividual,CstMtrlDrt,CstMtrlPrcd1,CstMtrlPrcd2,CstMtrlPrcd3,Header,SetorProducao,Categoria,Familia,ListaPlanejProducao,NeedComponProducao,ListaNecessProdNivel1,NecCompListaP1,ListaNecessProdNivel2,NecCompListaP2,ListaNecessProdNivel3,NecCompListaP3,ListaNecessProdNivel4,NecCompListaP4,NecTotalComponente,Mes1,Mes2,Mes3,Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12,Input")] Estrutura estrutura)
        {
            if (ModelState.IsValid)
            {
                db.Estruturas.Add(estrutura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", estrutura.ProdutoId);
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo", estrutura.SequenciaId);
            return View(estrutura);
        }

        // GET: PlanejNecessidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estrutura estrutura = db.Estruturas.Find(id);
            if (estrutura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", estrutura.ProdutoId);
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo", estrutura.SequenciaId);
            return View(estrutura);
        }

        // POST: PlanejNecessidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,UnidadeId,QtdCusto,SequenciaId,Item,DescCompProc,UnidadeCompraId,CustoUnitCompra,Onera,Lote,Perda,Observacao,PartCusto,QtEftvUntrCmpnt,CstCmprUndPrd,TpItmCst,AlrtSbPrdt,TempMaq,QtdUndd,PsLiqdFnl,PsLiqdPrcdt,HrsModFnl,HrsModPrec1,HrsModPrec2,IdProd,IdCmpnt,PdrHoraria,ProdComp,CstIndividual,CstMtrlDrt,CstMtrlPrcd1,CstMtrlPrcd2,CstMtrlPrcd3,Header,SetorProducao,Categoria,Familia,ListaPlanejProducao,NeedComponProducao,ListaNecessProdNivel1,NecCompListaP1,ListaNecessProdNivel2,NecCompListaP2,ListaNecessProdNivel3,NecCompListaP3,ListaNecessProdNivel4,NecCompListaP4,NecTotalComponente,Mes1,Mes2,Mes3,Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12,Input")] Estrutura estrutura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estrutura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", estrutura.ProdutoId);
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo", estrutura.SequenciaId);
            return View(estrutura);
        }

        // GET: PlanejNecessidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estrutura estrutura = db.Estruturas.Find(id);
            if (estrutura == null)
            {
                return HttpNotFound();
            }
            return View(estrutura);
        }

        // POST: PlanejNecessidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estrutura estrutura = db.Estruturas.Find(id);
            db.Estruturas.Remove(estrutura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var estruturas = db.Estruturas
                .Include(e => e.Produto)
                .Include(e => e.Sequencia)
                .Include(e => e.Unidade)
                .Include(e => e.UnidadeCompra)
                .Where(e => e.Produto.Apelido == search);

            if (!estruturas.Any())
            {
                DbLogger.Log(Reason.Info, $"Procura pela estrutura {search} não produziu resultado em PlanejNecessidades");
                return Content($"Item {search} não encontrado");
            }

            return View("Index", estruturas);
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
