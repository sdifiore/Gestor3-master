﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("Insumos")]
    public class InsumoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Insumoes
        [Route]
        public ActionResult Index(int? page)
        {
            //Populate.Insumo();

            var insumos = db.Insumos
                .Include(i => i.Categoria)
                .Include(i => i.ClasseCusto)
                .Include(i => i.Familia)
                .Include(i => i.Finalidade)
                .Include(i => i.Linha)
                .Include(i => i.Tipo)
                .Include(i => i.Unidade)
                .Include(i => i.UnidadeConsumo)
                .OrderBy(i => i.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = insumos.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Insumoes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var insumo = db.Insumos
                .Include(i => i.Categoria)
                .Include(i => i.ClasseCusto)
                .Include(i => i.Familia)
                .Include(i => i.Finalidade)
                .Include(i => i.Linha)
                .Include(i => i.Tipo)
                .Include(i => i.Unidade)
                .Include(i => i.UnidadeConsumo)
                .Single(i => i.InsumoId == id);

            if (insumo == null)
            {
                return HttpNotFound();
            }

            return View(insumo);
        }

        // GET: Insumoes/Create
        [Route("Criar")]
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao");
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Descricao");
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Descricao");
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao");
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Descricao");
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descricao");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Descricao");
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Descricao");

            return View();
        }

        // POST: Insumoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Criar")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Apelido,Descricao,UnidadeId,TipoId,ClasseCustoId,CategoriaId,FamiliaId,LinhaId,Peso,Cotacao,PrecoUsd,PrecoRs,Icms,Ipi,Pis,Cofins,DespExtra,DespImport,Ativo,FinalidadeId,UnidadeConsumoId,QtdUnddConsumo,QtdMltplCompra,FormaPgto,Prazo1,Prazo2,PctPgto1,ImportPzPagDes")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                insumo.Icms = insumo.Icms / 100;
                insumo.Ipi = insumo.Ipi / 100;
                insumo.Pis = insumo.Pis / 100;
                insumo.Cofins = insumo.Cofins / 100;
                insumo.PctPgto1 = insumo.PctPgto1 / 100;

                db.Insumos.Add(insumo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            insumo.Icms = insumo.Icms / 100;
            insumo.Ipi = insumo.Ipi / 100;
            insumo.Pis = insumo.Pis / 100;
            insumo.Cofins = insumo.Cofins / 100;
            insumo.PctPgto1 = insumo.PctPgto1 / 100;
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", insumo.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido", insumo.ClasseCustoId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", insumo.FamiliaId);
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao", insumo.FinalidadeId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", insumo.LinhaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido", insumo.TipoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Descricao");
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Descricao");

            return View(insumo);
        }

        // GET: Insumoes/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Insumo insumo = db.Insumos.Find(id);

            if (insumo == null)
            {
                return HttpNotFound();
            }

            insumo.Icms = insumo.Icms * 100;
            insumo.Ipi = insumo.Ipi * 100;
            insumo.Pis = insumo.Pis * 100;
            insumo.Cofins = insumo.Cofins * 100;
            insumo.PctPgto1 = insumo.PctPgto1 * 100;

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao", insumo.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Descricao", insumo.ClasseCustoId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Descricao", insumo.FamiliaId);
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao", insumo.FinalidadeId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Descricao", insumo.LinhaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descricao", insumo.TipoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Descricao", insumo.UnidadeId);
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Descricao", insumo.UnidadeConsumoId);

            return View(insumo);
        }

        // POST: Insumoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsumoId,Apelido,Descricao,UnidadeId,UnidadeConsumoId,TipoId,ClasseCustoId,CategoriaId,FamiliaId,LinhaId,Peso,Cotacao,PrecoUsd,PrecoRs,Icms,Ipi,Pis,Cofins,DespExtra,DespImport,Ativo,FinalidadeId,QtdUnddConsumo,QtdMltplCompra,FormaPgto,Prazo1,Prazo2,PctPgto1,ImportPzPagDesp,PrcBrtCompra,CrdtIcms,CrdtIpi,CrdtPis,CrdtCofins,SumCrdImpostos,DspImportacao,CustoExtra,Custo,CustoUndCnsm,PgtFornecImp,UsoStru")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                insumo.Icms = insumo.Icms / 100;
                insumo.Ipi = insumo.Ipi / 100;
                insumo.Pis = insumo.Pis / 100;
                insumo.Cofins = insumo.Cofins / 100;
                insumo.PctPgto1 = insumo.PctPgto1 / 100;

                db.Entry(insumo).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", insumo.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido", insumo.ClasseCustoId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", insumo.FamiliaId);
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao", insumo.FinalidadeId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", insumo.LinhaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido", insumo.TipoId);
            ViewBag.UnddId = new SelectList(db.Unidades, "UnidadeId", "Apelido", insumo.UnidadeId);
            ViewBag.UndConsId = new SelectList(db.Unidades, "UnidadeId", "Apelido", insumo.UnidadeConsumoId);

            return View(insumo);
        }

        // GET: Insumoes/Copy/5
        [Route("Copy")]
        public ActionResult Copy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Insumo insumo = db.Insumos.Find(id);

            if (insumo == null)
            {
                return HttpNotFound();
            }

            insumo.Apelido = "";
            insumo.Icms = insumo.Icms * 100;
            insumo.Ipi = insumo.Ipi * 100;
            insumo.Pis = insumo.Pis * 100;
            insumo.Cofins = insumo.Cofins * 100;
            insumo.PctPgto1 = insumo.PctPgto1 * 100;

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao", insumo.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Descricao", insumo.ClasseCustoId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Descricao", insumo.FamiliaId);
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao", insumo.FinalidadeId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Descricao", insumo.LinhaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Descricao", insumo.TipoId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Descricao", insumo.UnidadeId);
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Descricao", insumo.UnidadeConsumoId);

            return View(insumo);
        }

        // POST: Insumoes/Copy/5
        [HttpPost]
        [Route("Copy")]
        [ValidateAntiForgeryToken]
        public ActionResult Copy([Bind(Include = "InsumoId,Apelido,Descricao,UnidadeId,UnidadeConsumoId,TipoId,ClasseCustoId,CategoriaId,FamiliaId,LinhaId,Peso,Cotacao,PrecoUsd,PrecoRs,Icms,Ipi,Pis,Cofins,DespExtra,DespImport,Ativo,FinalidadeId,QtdUnddConsumo,QtdMltplCompra,FormaPgto,Prazo1,Prazo2,PctPgto1,ImportPzPagDesp,PrcBrtCompra,CrdtIcms,CrdtIpi,CrdtPis,CrdtCofins,SumCrdImpostos,DspImportacao,CustoExtra,Custo,CustoUndCnsm,PgtFornecImp,UsoStru")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                var duplicado = db.Insumos.SingleOrDefault(p => p.Apelido == insumo.Apelido);
                if (duplicado != null)
                {
                    DbLogger.Log(Reason.Info, $"Tentativa de duplicar Insumo {insumo.Apelido} sem sucesso.");
                    return Content($"Insumo {insumo.Apelido} já existe no cadastro e portanto não pode ser duplicado.");
                }
                    

                insumo.Icms = insumo.Icms / 100;
                insumo.Ipi = insumo.Ipi / 100;
                insumo.Pis = insumo.Pis / 100;
                insumo.Cofins = insumo.Cofins / 100;
                insumo.PctPgto1 = insumo.PctPgto1 / 100;

                db.Insumos.Add(insumo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", insumo.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido", insumo.ClasseCustoId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", insumo.FamiliaId);
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao", insumo.FinalidadeId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", insumo.LinhaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido", insumo.TipoId);
            ViewBag.UnddId = new SelectList(db.Unidades, "UnidadeId", "Apelido", insumo.UnidadeId);
            ViewBag.UndConsId = new SelectList(db.Unidades, "UnidadeId", "Apelido", insumo.UnidadeConsumoId);

            return View(insumo);
        }

        // GET: Insumoes/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var insumo = db.Insumos
                .Include(i => i.Categoria)
                .Include(i => i.ClasseCusto)
                .Include(i => i.Familia)
                .Include(i => i.Finalidade)
                .Include(i => i.Linha)
                .Include(i => i.Tipo)
                .Include(i => i.UnidadeConsumo)
                .Single(i => i.InsumoId == id);

            if (insumo == null)
            {
                return HttpNotFound();
            }

            return View(insumo);
        }

        // POST: Insumoes/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var insumo = db.Insumos
                .Include(i => i.Categoria)
                .Include(i => i.ClasseCusto)
                .Include(i => i.Familia)
                .Include(i => i.Finalidade)
                .Include(i => i.Linha)
                .Include(i => i.Tipo)
                .Include(i => i.UnidadeConsumo)
                .Single(i => i.InsumoId == id);

            return View("Erase", insumo);
        }

        // POST: Insumoes/Erase/5
        [HttpPost]
        [Route("Erase")]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Insumo insumo = db.Insumos.Find(id);
            db.Insumos.Remove(insumo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var insumo = db.Insumos
                .Include(i => i.Categoria)
                .Include(i => i.ClasseCusto)
                .Include(i => i.Familia)
                .Include(i => i.Finalidade)
                .Include(i => i.Linha)
                .Include(i => i.Tipo)
                .Include(i => i.UnidadeConsumo)
                .SingleOrDefault(i => i.Apelido == search);

            if (insumo == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo insumo {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", insumo);
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
