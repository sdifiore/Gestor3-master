using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class ResinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resinas
        public ActionResult Index(int? page)
        {
            var model = db.Resinas
                        .OrderBy(r => r.Descricao);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Resinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resina resina = db.Resinas.Find(id);
            if (resina == null)
            {
                return HttpNotFound();
            }
            return View(resina);
        }

        // GET: Resinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Resina resina)
        {
            if (ModelState.IsValid)
            {
                db.Resinas.Add(resina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resina);
        }

        // GET: Resinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resina resina = db.Resinas.Find(id);
            if (resina == null)
            {
                return HttpNotFound();
            }
            return View(resina);
        }

        // POST: Resinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Resina resina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resina);
        }

        // GET: Resinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resina resina = db.Resinas.Find(id);
            if (resina == null)
            {
                return HttpNotFound();
            }
            return View(resina);
        }

        // POST: Resinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resina resina = db.Resinas.Find(id);
            db.Resinas.Remove(resina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Resinas
                .FirstOrDefault(g => g.Descricao.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela Resina {search} não produziu resultado");
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
