using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("SemanasEstoque")]
    public class SemanaEstoquesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SemanaEstoques
        [Route]
        public ActionResult Index(int? page)
        {
            var model = db.SemanasEstoque
                        .OrderBy(s => s.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: SemanaEstoques/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemanaEstoque semanaEstoque = db.SemanasEstoque.Find(id);
            if (semanaEstoque == null)
            {
                return HttpNotFound();
            }
            return View(semanaEstoque);
        }

        // GET: SemanaEstoques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SemanaEstoques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apelido,Semanas")] SemanaEstoque semanaEstoque)
        {
            if (ModelState.IsValid)
            {
                db.SemanasEstoque.Add(semanaEstoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semanaEstoque);
        }

        // GET: SemanaEstoques/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemanaEstoque semanaEstoque = db.SemanasEstoque.Find(id);
            if (semanaEstoque == null)
            {
                return HttpNotFound();
            }
            return View(semanaEstoque);
        }

        // POST: SemanaEstoques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Semanas")] SemanaEstoque semanaEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semanaEstoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semanaEstoque);
        }

        // GET: SemanaEstoques/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemanaEstoque semanaEstoque = db.SemanasEstoque.Find(id);
            if (semanaEstoque == null)
            {
                return HttpNotFound();
            }
            return View(semanaEstoque);
        }

        // POST: SemanaEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SemanaEstoque semanaEstoque = db.SemanasEstoque.Find(id);
            return View("Erase", semanaEstoque);
        }

        // POST: SemanaEstoques/Erase/5
        [HttpPost]
        [Route("Erase")]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            SemanaEstoque semanaEstoque = db.SemanasEstoque.Find(id);
            db.SemanasEstoque.Remove(semanaEstoque);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(string search)
        {
            var model = db.SemanasEstoque
                .FirstOrDefault(g => g.Apelido.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela Semana de Estoque {search} não produziu resultado");
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
