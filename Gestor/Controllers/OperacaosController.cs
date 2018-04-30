// Custo_3.PlanejVendas

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class OperacaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Operacaos
        public ActionResult Index(int? page)
        {
            var operacoe = db.Operacoes
                .Include(o => o.Setor)
                .OrderBy(o => o.CodigoOperacao);

            var pageNumber = page ?? 1;
            var onePageHistory = operacoe.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Operacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacao operacao = db.Operacoes.Find(id);
            if (operacao == null)
            {
                return HttpNotFound();
            }
            return View(operacao);
        }

        // GET: Operacaos/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo");
            return View();
        }

        // POST: Operacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperacaoId,CodigoOperacao,SetorProducao,Descricao,TaxaOcupacao,IneficienciaAdotada,Comentario,QtdMaquinas,Custo,SetorId")] Operacao operacao)
        {
            if (ModelState.IsValid)
            {
                operacao.IneficienciaAdotada = operacao.IneficienciaAdotada / 100;
                operacao.TaxaOcupacao = operacao.TaxaOcupacao / 100;
                db.Operacoes.Add(operacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", operacao.SetorId);
            return View(operacao);
        }

        // GET: Operacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacao operacao = db.Operacoes.Find(id);
            if (operacao == null)
            {
                return HttpNotFound();
            }

            operacao.TaxaOcupacao = operacao.TaxaOcupacao * 100;
            operacao.IneficienciaAdotada = operacao.IneficienciaAdotada * 100;

            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", operacao.SetorId);
            return View(operacao);
        }

        // POST: Operacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperacaoId,CodigoOperacao,SetorProducao,Descricao,TaxaOcupacao,IneficienciaAdotada,Comentario,QtdMaquinas,Custo,SetorId")] Operacao operacao)
        {
            if (ModelState.IsValid)
            {
                operacao.TaxaOcupacao = operacao.TaxaOcupacao / 100;
                operacao.IneficienciaAdotada = operacao.IneficienciaAdotada / 100;
                db.Entry(operacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", operacao.SetorId);
            return View(operacao);
        }

        // GET: Operacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacao operacao = db.Operacoes.Find(id);
            if (operacao == null)
            {
                return HttpNotFound();
            }
            return View(operacao);
        }

        // POST: Operacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operacao operacao = db.Operacoes.Find(id);
            return View("Erase", operacao);
        }

        // POST: Operacaos/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Operacao operacao = db.Operacoes.Find(id);
            db.Operacoes.Remove(operacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var operacao = db.Operacoes.FirstOrDefault(o => o.CodigoOperacao == search);

            if (operacao == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela operação {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", operacao);
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
