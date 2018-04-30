using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class QtdEmbalagemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QtdEmbalagems
        public ViewResult Index(int? page)
        {
            var viewModel = db.QtdEmbalagems
                .Include(m => m.MedidaFita)
                .OrderBy(m => m.MedidaFita.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = viewModel.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: QtdEmbalagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QtdEmbalagem qtdEmbalagem = db.QtdEmbalagems.Find(id);
            if (qtdEmbalagem == null)
            {
                return HttpNotFound();
            }
            return View(qtdEmbalagem);
        }

        // GET: QtdEmbalagems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QtdEmbalagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QtdEmbalagemId,CartuchoRolCx,CartuchoCxPlt,DisplayRolCx,CarretelRolCx,CarretelCxPlt,MedidaFitasId")] QtdEmbalagem qtdEmbalagem)
        {
            if (ModelState.IsValid)
            {
                db.QtdEmbalagems.Add(qtdEmbalagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qtdEmbalagem);
        }

        // GET: QtdEmbalagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QtdEmbalagem qtdEmbalagem = db.QtdEmbalagems.Find(id);
            if (qtdEmbalagem == null)
            {
                return HttpNotFound();
            }
            return View(qtdEmbalagem);
        }

        // POST: QtdEmbalagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QtdEmbalagemId,CartuchoRolCx,CartuchoCxPlt,DisplayRolCx,CarretelRolCx,CarretelCxPlt,MedidaFitasId")] QtdEmbalagem qtdEmbalagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qtdEmbalagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qtdEmbalagem);
        }

        // GET: QtdEmbalagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QtdEmbalagem qtdEmbalagem = db.QtdEmbalagems.Find(id);
            if (qtdEmbalagem == null)
            {
                return HttpNotFound();
            }
            return View(qtdEmbalagem);
        }

        // POST: QtdEmbalagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QtdEmbalagem qtdEmbalagem = db.QtdEmbalagems.Find(id);
            return View("Erase", qtdEmbalagem);
        }

        // POST: QtdEmbalagems/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            QtdEmbalagem qtdEmbalagem = db.QtdEmbalagems.Find(id);
            db.QtdEmbalagems.Remove(qtdEmbalagem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.QtdEmbalagems
                .SingleOrDefault(g => g.MedidaFita.Apelido.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo ParmGraxa {search} não produziu resultado");
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
