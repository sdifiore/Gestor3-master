// Custo_3.PlanejVendas

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class UfsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ufs
        public ActionResult Index(int? page)
        {
            var model = db.Ufs.OrderBy(u => u.Sigla);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Ufs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = db.Ufs.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // GET: Ufs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ufs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sigla,Nome")] Uf uf)
        {
            if (ModelState.IsValid)
            {
                db.Ufs.Add(uf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uf);
        }

        // GET: Ufs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = db.Ufs.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // POST: Ufs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sigla,Nome")] Uf uf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uf);
        }

        // GET: Ufs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = db.Ufs.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // POST: Ufs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uf uf = db.Ufs.Find(id);
            db.Ufs.Remove(uf);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Ufs
                .FirstOrDefault(g => g.Sigla.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela UF {search} não produziu resultado");
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
