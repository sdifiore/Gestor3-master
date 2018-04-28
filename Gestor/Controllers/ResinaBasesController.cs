using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("ResinaBase")]
    public class ResinaBasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResinaBases
        [Route]
        public ActionResult Index(int? page)
        {
            var model = db.ResinasBase
                .OrderBy(r => r.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: ResinaBases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResinaBase resinaBase = db.ResinasBase.Find(id);
            if (resinaBase == null)
            {
                return HttpNotFound();
            }
            return View(resinaBase);
        }

        // GET: ResinaBases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResinaBases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apelido,Descricao")] ResinaBase resinaBase)
        {
            if (ModelState.IsValid)
            {
                db.ResinasBase.Add(resinaBase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resinaBase);
        }

        // GET: ResinaBases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResinaBase resinaBase = db.ResinasBase.Find(id);
            if (resinaBase == null)
            {
                return HttpNotFound();
            }
            return View(resinaBase);
        }

        // POST: ResinaBases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Descricao")] ResinaBase resinaBase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resinaBase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resinaBase);
        }

        // GET: ResinaBases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResinaBase resinaBase = db.ResinasBase.Find(id);
            if (resinaBase == null)
            {
                return HttpNotFound();
            }
            return View(resinaBase);
        }

        // POST: ResinaBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResinaBase resinaBase = db.ResinasBase.Find(id);
            db.ResinasBase.Remove(resinaBase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.ResinasBase
                .FirstOrDefault(g => g.Apelido.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela Resina Base {search} não produziu resultado");
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
