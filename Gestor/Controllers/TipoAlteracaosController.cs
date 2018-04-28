using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class TipoAlteracaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoAlteracaos
        public ActionResult Index(int? page)
        {
            var model = db.TiposAlteracao
                        .OrderBy(t => t.TipoAlteracaoId);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: TipoAlteracaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAlteracao tipoAlteracao = db.TiposAlteracao.Find(id);
            if (tipoAlteracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoAlteracao);
        }

        // GET: TipoAlteracaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAlteracaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoAlteracaoId,Descricao")] TipoAlteracao tipoAlteracao)
        {
            if (ModelState.IsValid)
            {
                db.TiposAlteracao.Add(tipoAlteracao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAlteracao);
        }

        // GET: TipoAlteracaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAlteracao tipoAlteracao = db.TiposAlteracao.Find(id);
            if (tipoAlteracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoAlteracao);
        }

        // POST: TipoAlteracaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoAlteracaoId,Descricao")] TipoAlteracao tipoAlteracao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAlteracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAlteracao);
        }

        // GET: TipoAlteracaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAlteracao tipoAlteracao = db.TiposAlteracao.Find(id);
            if (tipoAlteracao == null)
            {
                return HttpNotFound();
            }
            return View(tipoAlteracao);
        }

        // POST: TipoAlteracaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAlteracao tipoAlteracao = db.TiposAlteracao.Find(id);
            db.TiposAlteracao.Remove(tipoAlteracao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.TiposAlteracao
                .FirstOrDefault(g => g.Descricao.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Tipo Alteração {search} não produziu resultado");
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
