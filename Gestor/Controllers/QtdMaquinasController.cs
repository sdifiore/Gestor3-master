using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class QtdMaquinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QtdMaquinas
        public ActionResult Index(int? page)
        {
            var model = db.QtdMaquinas
                        .OrderBy(q => q.Linha);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: QtdMaquinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QtdMaquinas qtdMaquinas = db.QtdMaquinas.Find(id);
            if (qtdMaquinas == null)
            {
                return HttpNotFound();
            }
            return View(qtdMaquinas);
        }

        // GET: QtdMaquinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QtdMaquinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Linha,Descricao,QuantidadeMaquinas")] QtdMaquinas qtdMaquinas)
        {
            if (ModelState.IsValid)
            {
                db.QtdMaquinas.Add(qtdMaquinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qtdMaquinas);
        }

        // GET: QtdMaquinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QtdMaquinas qtdMaquinas = db.QtdMaquinas.Find(id);
            if (qtdMaquinas == null)
            {
                return HttpNotFound();
            }
            return View(qtdMaquinas);
        }

        // POST: QtdMaquinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Linha,Descricao,QuantidadeMaquinas")] QtdMaquinas qtdMaquinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qtdMaquinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qtdMaquinas);
        }

        // GET: QtdMaquinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QtdMaquinas qtdMaquinas = db.QtdMaquinas.Find(id);
            if (qtdMaquinas == null)
            {
                return HttpNotFound();
            }
            return View(qtdMaquinas);
        }

        // POST: QtdMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QtdMaquinas qtdMaquinas = db.QtdMaquinas.Find(id);
            db.QtdMaquinas.Remove(qtdMaquinas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.QtdMaquinas
                .SingleOrDefault(g => g.Linha == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela máquina ou linha {search} não produziu resultado");
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
