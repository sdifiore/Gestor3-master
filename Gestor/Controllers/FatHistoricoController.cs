using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class FatHistoricoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FatHistorico
        public ActionResult Index(int? page)
        {
            var cubosTrabalhados = db.CubosTrabalhados
                .Include(c => c.CategoriaCliente)
                .Include(c => c.Familia)
                .Include(c => c.GrupoRateio)
                .Include(c => c.Linha)
                .Include(c => c.Marca)
                .Include(c => c.TipoCliente)
                .Include(c => c.TipoVenda)
                .Include(c => c.Unidade)
                .Include( c => c.Categoria)
                .OrderBy(c => c.DataPedido)
                .ThenBy(c => c.Pedido)
                .ThenBy(c => c.Produto);

            var pageNumber = page ?? 1;
            var onePageHistory = cubosTrabalhados.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: FatHistorico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuboTrabalhado cuboTrabalhado = db.CubosTrabalhados.Find(id);
            if (cuboTrabalhado == null)
            {
                return HttpNotFound();
            }
            return View(cuboTrabalhado);
        }

        // GET: FatHistorico/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaClienteId = new SelectList(db.CategoriasCliente, "Id", "Categoria");
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido");
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Apelido");
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido");
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Descricao");
            ViewBag.TipoClienteId = new SelectList(db.TiposCliente, "Id", "Nome");
            ViewBag.TipoVendaId = new SelectList(db.TiposVenda, "Id", "Tipo");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido");
            return View();
        }

        // POST: FatHistorico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pedido,DataPedido,Cliente,UF,Cidade,Regiao,Codigo,Produto,CategoriaId,FamiliaId,LinhaId,MarcaId,Vendedor,FormaPagamento,DataValidade,TipoVendaId,DataFaturamento,NotaFiscal,Quantidade,ValorUnitario,ReceitaBruta,ValorIpi,ValorST,PrazoPagMedio,FatuBruto,MesCadastro,MesFatura,Faturado,MesEntregue,ClienteNfDataFat,CodigoAjustado,CodNomeProdutoUnidade,UnidadeId,QuantAjustada,PesoProduto,Juridico,TipoClienteId,CategoriaClienteId,SegmentoCliente,Grupo,PrazoEntrega,TaxaDolar,FatBrutoUsd,PrecoIndividual,ReceitaLiquida,Comissao,Frete,CustoFinancCobranca,GrupoRateioId,AnoFaturamento,TemPeso,PvRsKg,Trimestre,M2Fitas,RecBrutaUsd,CategoProdAjustadaId,PeriodoEstatistico,QuantIndividualAjustada,IdVend,CodRegiaoOriginal,VlIcms,VlCom,Cnpj,CodProdOriginal")] CuboTrabalhado cuboTrabalhado)
        {
            if (ModelState.IsValid)
            {
                db.CubosTrabalhados.Add(cuboTrabalhado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaClienteId = new SelectList(db.CategoriasCliente, "Id", "Categoria", cuboTrabalhado.CategoriaClienteId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", cuboTrabalhado.FamiliaId);
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Apelido", cuboTrabalhado.GrupoRateioId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", cuboTrabalhado.LinhaId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Descricao", cuboTrabalhado.MarcaId);
            ViewBag.TipoClienteId = new SelectList(db.TiposCliente, "Id", "Nome", cuboTrabalhado.TipoClienteId);
            ViewBag.TipoVendaId = new SelectList(db.TiposVenda, "Id", "Tipo", cuboTrabalhado.TipoVendaId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", cuboTrabalhado.UnidadeId);
            return View(cuboTrabalhado);
        }

        // GET: FatHistorico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuboTrabalhado cuboTrabalhado = db.CubosTrabalhados.Find(id);
            if (cuboTrabalhado == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaClienteId = new SelectList(db.CategoriasCliente, "Id", "Categoria", cuboTrabalhado.CategoriaClienteId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", cuboTrabalhado.FamiliaId);
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Apelido", cuboTrabalhado.GrupoRateioId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", cuboTrabalhado.LinhaId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Descricao", cuboTrabalhado.MarcaId);
            ViewBag.TipoClienteId = new SelectList(db.TiposCliente, "Id", "Nome", cuboTrabalhado.TipoClienteId);
            ViewBag.TipoVendaId = new SelectList(db.TiposVenda, "Id", "Tipo", cuboTrabalhado.TipoVendaId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", cuboTrabalhado.UnidadeId);
            return View(cuboTrabalhado);
        }

        // POST: FatHistorico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pedido,DataPedido,Cliente,UF,Cidade,Regiao,Codigo,Produto,CategoriaId,FamiliaId,LinhaId,MarcaId,Vendedor,FormaPagamento,DataValidade,TipoVendaId,DataFaturamento,NotaFiscal,Quantidade,ValorUnitario,ReceitaBruta,ValorIpi,ValorST,PrazoPagMedio,FatuBruto,MesCadastro,MesFatura,Faturado,MesEntregue,ClienteNfDataFat,CodigoAjustado,CodNomeProdutoUnidade,UnidadeId,QuantAjustada,PesoProduto,Juridico,TipoClienteId,CategoriaClienteId,SegmentoCliente,Grupo,PrazoEntrega,TaxaDolar,FatBrutoUsd,PrecoIndividual,ReceitaLiquida,Comissao,Frete,CustoFinancCobranca,GrupoRateioId,AnoFaturamento,TemPeso,PvRsKg,Trimestre,M2Fitas,RecBrutaUsd,CategoProdAjustadaId,PeriodoEstatistico,QuantIndividualAjustada,IdVend,CodRegiaoOriginal,VlIcms,VlCom,Cnpj,CodProdOriginal")] CuboTrabalhado cuboTrabalhado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuboTrabalhado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaClienteId = new SelectList(db.CategoriasCliente, "Id", "Categoria", cuboTrabalhado.CategoriaClienteId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", cuboTrabalhado.FamiliaId);
            ViewBag.GrupoRateioId = new SelectList(db.GruposRateio, "GrupoRateioId", "Apelido", cuboTrabalhado.GrupoRateioId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", cuboTrabalhado.LinhaId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Descricao", cuboTrabalhado.MarcaId);
            ViewBag.TipoClienteId = new SelectList(db.TiposCliente, "Id", "Nome", cuboTrabalhado.TipoClienteId);
            ViewBag.TipoVendaId = new SelectList(db.TiposVenda, "Id", "Tipo", cuboTrabalhado.TipoVendaId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", cuboTrabalhado.UnidadeId);
            return View(cuboTrabalhado);
        }

        // GET: FatHistorico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuboTrabalhado cuboTrabalhado = db.CubosTrabalhados.Find(id);
            if (cuboTrabalhado == null)
            {
                return HttpNotFound();
            }
            return View(cuboTrabalhado);
        }

        // POST: FatHistorico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuboTrabalhado cuboTrabalhado = db.CubosTrabalhados.Find(id);
            db.CubosTrabalhados.Remove(cuboTrabalhado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Pedido(int? page,string pedido)
        {
            string memoria;

            if (pedido == null)
            {
                memoria = (string)Session["Pedido"];
            }
            else
            {
                memoria = pedido;
                Session["Pedido"] = pedido;
            }

            var cubo = db.CubosTrabalhados
                .Include(c => c.CategoriaCliente)
                .Include(c => c.Familia)
                .Include(c => c.GrupoRateio)
                .Include(c => c.Linha)
                .Include(c => c.Marca)
                .Include(c => c.TipoCliente)
                .Include(c => c.TipoVenda)
                .Include(c => c.Unidade)
                .Include(c => c.Categoria)
                .Where(c => c.Pedido == memoria)
                .OrderBy(c => c.DataPedido)
                .ThenBy(c => c.Pedido)
                .ThenBy(c => c.Produto);

                if (cubo == null)
                {
                    DbLogger.Log(Reason.Info, $"Procura pelo Cubo Trabalhado {pedido} não produziu resultado em FatHistorico");
                    return Content($"Item {pedido} não encontrado");
                }

            var pageNumber = page ?? 1;
            var onePageHistory = cubo.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        public ActionResult NotaFiscal(int? page, string notafiscal)
        {
            string memoria;

            if (notafiscal == null)
            {
                memoria = (string)Session["NotaFiscal"];
            }
            else
            {
                memoria = notafiscal;
                Session["NotaFiscal"] = notafiscal;
            }

            var cubo = db.CubosTrabalhados
                .Include(c => c.CategoriaCliente)
                .Include(c => c.Familia)
                .Include(c => c.GrupoRateio)
                .Include(c => c.Linha)
                .Include(c => c.Marca)
                .Include(c => c.TipoCliente)
                .Include(c => c.TipoVenda)
                .Include(c => c.Unidade)
                .Include(c => c.Categoria)
                .Where(c => c.NotaFiscal == memoria)
                .OrderBy(c => c.DataPedido)
                .ThenBy(c => c.Pedido)
                .ThenBy(c => c.Produto);

            if (cubo == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela Nota Fiscal {notafiscal} não produziu resultado em FatHistorico");
                return Content($"Item {notafiscal} não encontrado");
            }

            var pageNumber = page ?? 1;
            var onePageHistory = cubo.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
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
