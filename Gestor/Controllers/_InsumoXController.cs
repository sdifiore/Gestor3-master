using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestor.Models;

namespace Gestor.Controllers
{
    public class _InsumoXController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: _InsumoX
        public ActionResult Index()
        {
            var insumos = db.Insumos.Include(i => i.Categoria).Include(i => i.ClasseCusto).Include(i => i.Familia).Include(i => i.Finalidade).Include(i => i.Linha).Include(i => i.Tipo).Include(i => i.UnidadeConsumo);
            return View(insumos.ToList());
        }

        // GET: _InsumoX/Details/5
        public ActionResult Details(int? id)
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
            return View(insumo);
        }

        // GET: _InsumoX/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido");
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido");
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido");
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao");
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido");
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido");
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Apelido");
            return View();
        }

        // POST: _InsumoX/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsumoId,Apelido,Descricao,UnidadeId,TipoId,ClasseCustoId,CategoriaId,FamiliaId,LinhaId,Peso,Cotacao,PrecoUsd,PrecoRs,Icms,Ipi,Pis,Cofins,DespExtra,DespImport,Ativo,FinalidadeId,UnidadeConsumoId,QtdUnddConsumo,QtdMltplCompra,FormaPgto,Prazo1,Prazo2,PctPgto1,ImportPzPagDesp,PrcBrtCompra,CrdtIcms,CrdtIpi,CrdtPis,CrdtCofins,SumCrdImpostos,DspImportacao,CustoExtra,Custo,CustoUndCnsm,PgtFornecImp,UsoStru")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
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
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Apelido", insumo.UnidadeConsumoId);
            return View(insumo);
        }

        // GET: _InsumoX/Edit/5
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
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Apelido", insumo.CategoriaId);
            ViewBag.ClasseCustoId = new SelectList(db.ClassesCusto, "ClasseCustoId", "Apelido", insumo.ClasseCustoId);
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Apelido", insumo.FamiliaId);
            ViewBag.FinalidadeId = new SelectList(db.Finalidades, "FinalidadeId", "Descricao", insumo.FinalidadeId);
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Apelido", insumo.LinhaId);
            ViewBag.TipoId = new SelectList(db.Tipos, "TipoId", "Apelido", insumo.TipoId);
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Apelido", insumo.UnidadeConsumoId);
            return View(insumo);
        }

        // POST: _InsumoX/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsumoId,Apelido,Descricao,UnidadeId,TipoId,ClasseCustoId,CategoriaId,FamiliaId,LinhaId,Peso,Cotacao,PrecoUsd,PrecoRs,Icms,Ipi,Pis,Cofins,DespExtra,DespImport,Ativo,FinalidadeId,UnidadeConsumoId,QtdUnddConsumo,QtdMltplCompra,FormaPgto,Prazo1,Prazo2,PctPgto1,ImportPzPagDesp,PrcBrtCompra,CrdtIcms,CrdtIpi,CrdtPis,CrdtCofins,SumCrdImpostos,DspImportacao,CustoExtra,Custo,CustoUndCnsm,PgtFornecImp,UsoStru")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
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
            ViewBag.UnidadeConsumoId = new SelectList(db.Unidades, "UnidadeId", "Apelido", insumo.UnidadeConsumoId);
            return View(insumo);
        }

        // GET: _InsumoX/Delete/5
        public ActionResult Delete(int? id)
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
            return View(insumo);
        }

        // POST: _InsumoX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insumo insumo = db.Insumos.Find(id);
            db.Insumos.Remove(insumo);
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
