﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class EstruturasControllerNew : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estruturas
        public ActionResult Index()
        {
            var estruturas = db.Estruturas
                            .Include(e => e.Categoria)
                            .Include(e => e.Familia)
                            .Include(e => e.Linha)
                            .Include(e => e.Produto)
                            .Include(e => e.Sequencia);

            return View(estruturas.ToList());
        }

        // GET: Estruturas/Details/5
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

        // GET: Estruturas/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido");
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido");
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo");
            return View();
        }

        // POST: Estruturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,UnidadeId,QtdCusto,SequenciaId,Item,DescCompProc,UnidadeCompraId,CustoUnitCompra,Onera,Lote,Perda,Observacao,PartCusto,QtEftvUntrCmpnt,CstCmprUndPrd,CustoIndividual,QtdUndd,RefAuxiliarProduto,TpItmCst,CategoriaId,FamiliaId,LinhaId,AlrtSbPrdt,TempMaq,TipoItemCusto,PsLiqdFnl,PsLiqdPrcdt,HrsModFnl,HrsModPrec1,HrsModPrec2,IdProd,IdCmpnt,PdrHoraria,ProdComp,CstIndividual,CstMtrlDrt,CstMtrlPrcd1,CstMtrlPrcd2,CstMtrlPrcd3,Header,SetorProducao,ListaPlanejProducao,NeedComponProducao,ListaNecessProdNivel1,NecCompListaP1,ListaNecessProdNivel2,NecCompListaP2,ListaNecessProdNivel3,NecCompListaP3,ListaNecessProdNivel4,NecCompListaP4,NecTotalComponente,Mes1,Mes2,Mes3,Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12,Input")] Estrutura estrutura)
        {
            if (ModelState.IsValid)
            {
                db.Estruturas.Add(estrutura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", estrutura.CategoriaId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", estrutura.FamiliaId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", estrutura.LinhaId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", estrutura.ProdutoId);
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo", estrutura.SequenciaId);
            return View(estrutura);
        }

        // GET: Estruturas/Edit/5
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
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", estrutura.CategoriaId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", estrutura.FamiliaId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", estrutura.LinhaId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", estrutura.ProdutoId);
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo", estrutura.SequenciaId);
            ViewBag.UnidadeCompraId = new SelectList(db.Unidades, "UnidadeId", "Apelido", estrutura.UnidadeCompraId);
            return View(estrutura);
        }

        // POST: Estruturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,UnidadeId,QtdCusto,SequenciaId,Item,DescCompProc,UnidadeCompraId,CustoUnitCompra,Onera,Lote,Perda,Observacao,PartCusto,QtEftvUntrCmpnt,CstCmprUndPrd,CustoIndividual,QtdUndd,RefAuxiliarProduto,TpItmCst,CategoriaId,FamiliaId,LinhaId,AlrtSbPrdt,TempMaq,TipoItemCusto,PsLiqdFnl,PsLiqdPrcdt,HrsModFnl,HrsModPrec1,HrsModPrec2,IdProd,IdCmpnt,PdrHoraria,ProdComp,CstIndividual,CstMtrlDrt,CstMtrlPrcd1,CstMtrlPrcd2,CstMtrlPrcd3,Header,SetorProducao,ListaPlanejProducao,NeedComponProducao,ListaNecessProdNivel1,NecCompListaP1,ListaNecessProdNivel2,NecCompListaP2,ListaNecessProdNivel3,NecCompListaP3,ListaNecessProdNivel4,NecCompListaP4,NecTotalComponente,Mes1,Mes2,Mes3,Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12,Input")] Estrutura estrutura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estrutura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", estrutura.CategoriaId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", estrutura.FamiliaId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", estrutura.LinhaId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", estrutura.ProdutoId);
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo", estrutura.SequenciaId);
            ViewBag.UnidadeCompraId = new SelectList(db.Unidades, "UnidadeId", "Apelido", estrutura.UnidadeCompraId);
            return View(estrutura);
        }

        // GET: Estruturas/Delete/5
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

        // POST: Estruturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estrutura estrutura = db.Estruturas.Find(id);
            return View("Erase", estrutura);
        }

        // POST: Estruturas/Erase/5
        [HttpPost, ActionName("Erase")]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Estrutura estrutura = db.Estruturas.Find(id);
            db.Estruturas.Remove(estrutura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search(int? page, string search)
        {
            string memoria;

            if (search == null)
            {
                memoria = (string)Session["Estrutura"];
            }
            else
            {
                memoria = search;
                Session["Estrutura"] = search;
            }

            var model = db.Estruturas
                        .Include(e => e.Categoria)
                        .Include(e => e.Familia)
                        .Include(e => e.Linha)
                        .Include(e => e.Produto)
                        .Include(e => e.Sequencia)
                        .OrderBy(e => e.Produto.Apelido);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela estrutura {search} não produziu resultado em Estruturas");
                return Content($"Item {search} não encontrado");
            }

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, 3);

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
