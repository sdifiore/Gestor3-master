using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class AjustesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ajustes
        public ActionResult Index(int? page)
        {
            var ajustes = db.Ajustes
                .Include(a => a.Atual)
                .Include(a => a.TipoAlteracao)
                .Include(a => a.UnidadeDe)
                .Include(a => a.UnidadePara)
                .OrderBy(a => a.CodigoOriginal);

            var pageNumber = page ?? 1;
            var onePageHistory = ajustes.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Ajustes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ajuste ajuste = db.Ajustes
                .Include(a => a.Atual)
                .Include(a => a.TipoAlteracao)
                .SingleOrDefault(a => a.AjusteId == id);

            if (ajuste == null)
            {
                return HttpNotFound();
            }
            return View(ajuste);
        }

        // GET: Ajustes/Create
        public ActionResult Create()
        {
            ViewBag.AtualId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.OrigemId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.TipoAlteracaoId = new SelectList(db.TiposAlteracao, "TipoAlteracaoId", "Descricao");
            return View();
        }

        // POST: Ajustes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AjusteId,OrigemId,UnidadeDeId,AtualId,UnidadeParaId,Fator,TipoAlteracaoId,Medida")] Ajuste ajuste)
        {
            if (ModelState.IsValid)
            {
                db.Ajustes.Add(ajuste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtualId = new SelectList(db.Produtos, "Id", "Apelido", ajuste.AtualId);
            ViewBag.TipoAlteracaoId = new SelectList(db.TiposAlteracao, "TipoAlteracaoId", "Descricao", ajuste.TipoAlteracaoId);
            return View(ajuste);
        }

        // GET: Ajustes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ajuste ajuste = db.Ajustes.Find(id);
            if (ajuste == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtualId = new SelectList(db.Produtos, "Id", "Apelido", ajuste.AtualId);
            ViewBag.TipoAlteracaoId = new SelectList(db.TiposAlteracao, "TipoAlteracaoId", "Descricao", ajuste.TipoAlteracaoId);
            return View(ajuste);
        }

        // POST: Ajustes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AjusteId,OrigemId,UnidadeDeId,AtualId,UnidadeParaId,Fator,TipoAlteracaoId,Medida")] Ajuste ajuste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ajuste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtualId = new SelectList(db.Produtos, "Id", "Apelido", ajuste.AtualId);
            ViewBag.TipoAlteracaoId = new SelectList(db.TiposAlteracao, "TipoAlteracaoId", "Descricao", ajuste.TipoAlteracaoId);
            return View(ajuste);
        }

        // GET: Ajustes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ajuste ajuste = db.Ajustes
                .Include(a => a.Atual)
                .Include(a => a.TipoAlteracao)
                .SingleOrDefault(a => a.AjusteId == id);

            if (ajuste == null)
            {
                return HttpNotFound();
            }
            return View(ajuste);
        }

        // POST: Ajustes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ajuste ajuste = db.Ajustes.Find(id);
            db.Ajustes.Remove(ajuste);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var ajuste = db.Ajustes
                .Include(a => a.Atual)
                .Include(a => a.TipoAlteracao)
                .FirstOrDefault(a => a.CodigoOriginal == search);

            if (ajuste == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo item de substituição {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", ajuste);
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
