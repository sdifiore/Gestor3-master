using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("DespesasExportacao")]
    public class DespesaExportacaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DespesaExportacaos
        [Route]
        public ActionResult Index(int? page)
        {
            var model = db.DespesasExportacao
                        .OrderBy(d => d.Tipo);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: DespesaExportacaos/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DespesaExportacao despesaExportacao = db.DespesasExportacao.Find(id);
            if (despesaExportacao == null)
            {
                return HttpNotFound();
            }
            return View(despesaExportacao);
        }

        // GET: DespesaExportacaos/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DespesaExportacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Valor,Descricao")] DespesaExportacao despesaExportacao)
        {
            if (ModelState.IsValid)
            {
                db.DespesasExportacao.Add(despesaExportacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(despesaExportacao);
        }

        // GET: DespesaExportacaos/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DespesaExportacao despesaExportacao = db.DespesasExportacao.Find(id);
            if (despesaExportacao == null)
            {
                return HttpNotFound();
            }

            despesaExportacao.Valor = despesaExportacao.Valor * 100;

            return View(despesaExportacao);
        }

        // POST: DespesaExportacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Valor,Descricao")] DespesaExportacao despesaExportacao)
        {
            if (ModelState.IsValid)
            {
                despesaExportacao.Valor = despesaExportacao.Valor / 100;
                db.Entry(despesaExportacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(despesaExportacao);
        }

        // GET: DespesaExportacaos/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DespesaExportacao despesaExportacao = db.DespesasExportacao.Find(id);
            if (despesaExportacao == null)
            {
                return HttpNotFound();
            }
            return View(despesaExportacao);
        }

        // POST: DespesaExportacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DespesaExportacao despesaExportacao = db.DespesasExportacao.Find(id);
            return View("Erase", despesaExportacao);
        }

        // POST: DespesaExportacaos/Erase/5
        [HttpPost, ActionName("Erase")]
        [Route("Erase")]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            DespesaExportacao despesaExportacao = db.DespesasExportacao.Find(id);
            db.DespesasExportacao.Remove(despesaExportacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(string search)
        {
            var model = db.DespesasExportacao
                .SingleOrDefault(g => g.Tipo == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela Despesa Exportação {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", model);
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
