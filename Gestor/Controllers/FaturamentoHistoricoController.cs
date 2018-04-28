using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;

namespace Gestor.Controllers
{
    public class FaturamentoHistoricoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FaturamentoHistorico
        public ActionResult Index()
        {
            var fatHistoricos = db.FatHistoricos
                .Include(f => f.Produto)
                .Include(f => f.ProdutoAjustado);

            return View(fatHistoricos.ToList());
        }

        // GET: FaturamentoHistorico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fatHistorico = db.FatHistoricos
                .Include(f => f.Produto)
                .Include(f => f.ProdutoAjustado)
                .SingleOrDefault(F => F.Id == id);

            if (fatHistorico == null)
            {
                return HttpNotFound();
            }
            return View(fatHistorico);
        }

        // GET: FaturamentoHistorico/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.ProdutoAjustadoId = new SelectList(db.Produtos, "Id", "Apelido");
            return View();
        }

        // POST: FaturamentoHistorico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroPedido,DataPedido,Cliente,Estado,Cidade,Regiao,ProdutoId,Vendedor,FormaPagamento,DataValidade,TipoVenda,DataFaturamento,NotaFiscal,Quantidade,ValorUnitario,ValorMercadoria,ValorIpi,ValorSubstTributaria,PrazoMedioRecebimento,RecBruta,FaturBruto,MesCadastro,AnoMesFatura,Situacao,MesEntrega,ClientePedido,ProdutoAjustadoId,NaturCli,PesoProduto,TipoCliente,CategoriaCliente,SegmentoCliente,Grupo,PrazoEntrega,TxDolar,FatBrutoUsd,PrecoIndividual,ReceitaLiquida,Comissao,Frete,CstFinBobranca,QuantAjustada,Icms,PrazoFatur,HorasMod,ComGvComacs,DescrProdAjustado,ProdCategoriaAjustado")] FatHistorico fatHistorico)
        {
            if (ModelState.IsValid)
            {
                db.FatHistoricos.Add(fatHistorico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", fatHistorico.ProdutoId);
            ViewBag.ProdutoAjustadoId = new SelectList(db.Produtos, "Id", "Apelido", fatHistorico.ProdutoAjustadoId);
            return View(fatHistorico);
        }

        // GET: FaturamentoHistorico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var fatHistorico = db.FatHistoricos
                .Include(f => f.Produto)
                .Include(f => f.ProdutoAjustado)
                .SingleOrDefault(F => F.Id == id);


            if (fatHistorico == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", fatHistorico.ProdutoId);
            ViewBag.ProdutoAjustadoId = new SelectList(db.Produtos, "Id", "Apelido", fatHistorico.ProdutoAjustadoId);
            return View(fatHistorico);
        }

        // POST: FaturamentoHistorico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroPedido,DataPedido,Cliente,Estado,Cidade,Regiao,ProdutoId,Vendedor,FormaPagamento,DataValidade,TipoVenda,DataFaturamento,NotaFiscal,Quantidade,ValorUnitario,ValorMercadoria,ValorIpi,ValorSubstTributaria,PrazoMedioRecebimento,RecBruta,FaturBruto,MesCadastro,AnoMesFatura,Situacao,MesEntrega,ClientePedido,ProdutoAjustadoId,NaturCli,PesoProduto,TipoCliente,CategoriaCliente,SegmentoCliente,Grupo,PrazoEntrega,TxDolar,FatBrutoUsd,PrecoIndividual,ReceitaLiquida,Comissao,Frete,CstFinBobranca,QuantAjustada,Icms,PrazoFatur,HorasMod,ComGvComacs,DescrProdAjustado,ProdCategoriaAjustado")] FatHistorico fatHistorico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatHistorico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", fatHistorico.ProdutoId);
            ViewBag.ProdutoAjustadoId = new SelectList(db.Produtos, "Id", "Apelido", fatHistorico.ProdutoAjustadoId);
            return View(fatHistorico);
        }

        // GET: FaturamentoHistorico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fatHistorico = db.FatHistoricos
                .Include(f => f.Produto)
                .Include(f => f.ProdutoAjustado)
                .SingleOrDefault(F => F.Id == id);

            if (fatHistorico == null)
            {
                return HttpNotFound();
            }
            return View(fatHistorico);
        }

        // POST: FaturamentoHistorico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FatHistorico fatHistorico = db.FatHistoricos.Find(id);
            db.FatHistoricos.Remove(fatHistorico);
            db.SaveChanges();
            return RedirectToAction("Index");
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
