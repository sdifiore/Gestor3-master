using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("Produtos")]
    public class ProdutoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produtoes
        [Route]
        public ActionResult Index(int? page)
        {
            var produtos = db.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ClasseCusto)
                .Include(p => p.Dominio)
                .Include(p => p.Familia)
                .Include(p => p.GrupoRateio)
                .Include(p => p.Linha)
                .Include(p => p.MedidaFita)
                .Include(p => p.Tipo)
                .Include(p => p.Unidade)
                .Include(p => p.TipoProd)
                .OrderBy(p => p.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = produtos.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Produtoes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ClasseCusto)
                .Include(p => p.Dominio)
                .Include(p => p.Familia)
                .Include(p => p.GrupoRateio)
                .Include(p => p.Linha)
                .Include(p => p.Tipo)
                .Include(p => p.Unidade)
                .SingleOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao");
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Descricao");
            ViewBag.DominioId = new SelectList(db.Dominios, "DominioId", "Descricao");
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Descricao");
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Descricao");
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Descricao");
            ViewBag.MedidaFitaId = new SelectList(db.MedidaFitas, "MedidaFitaId", "Apelido");
            ViewBag.PcpId = new SelectList(db.Pcps, "PcpId", "Descricao");
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descricao");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Descricao");
            ViewBag.TipoProducaoId = new SelectList(db.TiposProducao, "TipoProducaoId", "Descricao");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "Id,Apelido,Descricao,UnidadeId,TipoId,ClasseCustoId,CategoriaId,FamiliaId,LinhaId,GrupoRateioId,PesoLiquido,Ativo,Ipi,QtdUnid,DominioId,TipoProdId,PcpId,QtUnPorUnArmz,PesoLiquidoCalc,ItemStru,CustODirTotal,CstMatUltmEtapa,CstMatEtapa1,CstMatEtapa2,CstMatEtapa3,CstTotMaterial,CustoDirMod,HorasModUltmEtapa,HorasModEtapa1,HorasModEtapa2,HorasModTotal,CapProdHora,LoteMinimo,UsoStru,CustoDir,RelModCstDir,PctMatEtapaFinal,PctMatEtapa1,PctMatEtapa2,PctMatEtapa3,Input,CustoFixoTotal,MoiFabricacao,OutrosCustosFab,ComacsComtexFpv,CustoFixoAdminFpv,RsMoiDespFabHMod,RsSgNAHMod,CustoFixoTotalAnr,MoiFabricAnr,OutrosCustosFabricAnr,CustoFixoComacsCmtexAnr,CustoFixoAdminAnr,MedidaFitaId,DescricaoUnidade,Acoes,EventosAGVendasHistorico,Acao,Codigo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.Ipi = produto.Ipi / 100;
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", produto.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido", produto.ClasseCustoId);
            ViewBag.DominioId = new SelectList(db.Dominios, "DominioId", "Descricao", produto.DominioId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", produto.FamiliaId);
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Descricao", produto.GrupoRateioId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", produto.LinhaId);
            ViewBag.MedidaFitaId = new SelectList(db.MedidaFitas, "MedidaFitaId", "Apelido", produto.MedidaFitaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido", produto.TipoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", produto.UnidadeId);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            produto.PctPtfePeso = produto.PctPtfePeso * 100;
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", produto.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido", produto.ClasseCustoId);
            ViewBag.DominioId = new SelectList(db.Dominios, "DominioId", "Descricao", produto.DominioId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", produto.FamiliaId);
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Descricao", produto.GrupoRateioId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", produto.LinhaId);
            ViewBag.MedidaFitaId = new SelectList(db.MedidaFitas, "MedidaFitaId", "Apelido", produto.MedidaFitaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido", produto.TipoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", produto.UnidadeId);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Descricao,UnidadeId,TipoId,ClasseCustoId,CategoriaId,FamiliaId,LinhaId,GrupoRateioId,PesoLiquido,Ativo,Ipi,QtdUnid,DominioId,TipoProdId,PcpId,QtUnPorUnArmz,PesoLiquidoCalc,ItemStru,CustODirTotal,CstMatUltmEtapa,CstMatEtapa1,CstMatEtapa2,CstMatEtapa3,CstTotMaterial,CustoDirMod,HorasModUltmEtapa,HorasModEtapa1,HorasModEtapa2,HorasModTotal,CapProdHora,LoteMinimo,UsoStru,CustoDir,RelModCstDir,PctMatEtapaFinal,PctMatEtapa1,PctMatEtapa2,PctMatEtapa3,Input,CustoFixoTotal,MoiFabricacao,OutrosCustosFab,ComacsComtexFpv,CustoFixoAdminFpv,RsMoiDespFabHMod,RsSgNAHMod,CustoFixoTotalAnr,MoiFabricAnr,OutrosCustosFabricAnr,CustoFixoComacsCmtexAnr,CustoFixoAdminAnr,MedidaFitaId,DescricaoUnidade,Acoes,EventosAGVendasHistorico,Acao,Codigo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            produto.PctPtfePeso = produto.PctPtfePeso / 100;
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", produto.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido", produto.ClasseCustoId);
            ViewBag.DominioId = new SelectList(db.Dominios, "DominioId", "Descricao", produto.DominioId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", produto.FamiliaId);
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Descricao", produto.GrupoRateioId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", produto.LinhaId);
            ViewBag.MedidaFitaId = new SelectList(db.MedidaFitas, "MedidaFitaId", "Apelido", produto.MedidaFitaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido", produto.TipoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", produto.UnidadeId);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ClasseCusto)
                .Include(p => p.Dominio)
                .Include(p => p.Familia)
                .Include(p => p.GrupoRateio)
                .Include(p => p.Linha)
                .Include(p => p.Tipo)
                .Include(p => p.Unidade)
                .SingleOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Familias/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = db.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ClasseCusto)
                .Include(p => p.Dominio)
                .Include(p => p.Familia)
                .Include(p => p.GrupoRateio)
                .Include(p => p.Linha)
                .Include(p => p.Tipo)
                .Include(p => p.Unidade)
                .SingleOrDefault(p => p.Id == id);

            return View("Erase", produto);
        }

        // POST: Familias/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            var produto = db.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ClasseCusto)
                .Include(p => p.Dominio)
                .Include(p => p.Familia)
                .Include(p => p.GrupoRateio)
                .Include(p => p.Linha)
                .Include(p => p.Tipo)
                .Include(p => p.Unidade)
                .SingleOrDefault(p => p.Id == id);
            db.Produtos.Remove(produto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var produto = db.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ClasseCusto)
                .Include(p => p.Dominio)
                .Include(p => p.Familia)
                .Include(p => p.GrupoRateio)
                .Include(p => p.Linha)
                .Include(p => p.Tipo)
                .Include(p => p.Unidade)
                .SingleOrDefault(p => p.Apelido == search);

            if (produto == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo produto {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }
            return View("Details", produto);
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
