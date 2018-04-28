using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class DominiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dominios
        public ActionResult Index(int? page)
        {
            var model = db.Dominios
                        .OrderBy(d => d.Descricao);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Dominios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dominio dominio = db.Dominios.Find(id);
            if (dominio == null)
            {
                return HttpNotFound();
            }
            return View(dominio);
        }

        // GET: Dominios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dominios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DominioId,Descricao")] Dominio dominio)
        {
            if (ModelState.IsValid)
            {
                db.Dominios.Add(dominio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dominio);
        }

        // GET: Dominios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dominio dominio = db.Dominios.Find(id);
            if (dominio == null)
            {
                return HttpNotFound();
            }
            return View(dominio);
        }

        // POST: Dominios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DominioId,Descricao")] Dominio dominio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dominio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dominio);
        }

        // GET: Dominios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dominio dominio = db.Dominios.Find(id);
            if (dominio == null)
            {
                return HttpNotFound();
            }
            return View(dominio);
        }

        // POST: Dominios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dominio dominio = db.Dominios.Find(id);
            db.Dominios.Remove(dominio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Dominios
                .SingleOrDefault(g => g.Descricao == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Domínio {search} não produziu resultado");
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
