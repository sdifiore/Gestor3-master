using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class IndicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Indices
        public ActionResult Index(int? page)
        {
            var model = db.Indices
                        .OrderBy(i => i.Id);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Indices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indice indice = db.Indices.Find(id);
            if (indice == null)
            {
                return HttpNotFound();
            }
            return View(indice);
        }

        // GET: Indices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Proprio,Terceiros,Exportacao")] Indice indice)
        {
            if (ModelState.IsValid)
            {
                db.Indices.Add(indice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indice);
        }

        // GET: Indices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indice indice = db.Indices.Find(id);
            if (indice == null)
            {
                return HttpNotFound();
            }
            return View(indice);
        }

        // POST: Indices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Proprio,Terceiros,Exportacao")] Indice indice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indice);
        }

        // GET: Indices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indice indice = db.Indices.Find(id);
            if (indice == null)
            {
                return HttpNotFound();
            }
            return View(indice);
        }

        // POST: Indices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indice indice = db.Indices.Find(id);
            return View("Erase", indice);
        }

        // POST: Indices/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Indice indice = db.Indices.Find(id);
            db.Indices.Remove(indice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Indices
                .FirstOrDefault(g => g.Descricao.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo índice {search} não produziu resultado");
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
