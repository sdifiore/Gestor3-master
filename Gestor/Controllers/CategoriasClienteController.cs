using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class CategoriasClienteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoriasCliente
        public ActionResult Index(int? page)
        {
            var model = db.CategoriasCliente
                .OrderBy(c => c.Codigo);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: CategoriasCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaCliente categoriaCliente = db.CategoriasCliente.Find(id);
            if (categoriaCliente == null)
            {
                return HttpNotFound();
            }
            return View(categoriaCliente);
        }

        // GET: CategoriasCliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Categoria,Descricao")] CategoriaCliente categoriaCliente)
        {
            if (ModelState.IsValid)
            {
                db.CategoriasCliente.Add(categoriaCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaCliente);
        }

        // GET: CategoriasCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaCliente categoriaCliente = db.CategoriasCliente.Find(id);
            if (categoriaCliente == null)
            {
                return HttpNotFound();
            }
            return View(categoriaCliente);
        }

        // POST: CategoriasCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Categoria,Descricao")] CategoriaCliente categoriaCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaCliente);
        }

        // GET: CategoriasCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaCliente categoriaCliente = db.CategoriasCliente.Find(id);
            if (categoriaCliente == null)
            {
                return HttpNotFound();
            }
            return View(categoriaCliente);
        }

        // POST: Estruturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaCliente categoriaCliente = db.CategoriasCliente.Find(id);
            return View("Erase", categoriaCliente);
        }

        // POST: Estruturas/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            CategoriaCliente categoriaCliente = db.CategoriasCliente.Find(id);
            db.CategoriasCliente.Remove(categoriaCliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.CategoriasCliente
                .SingleOrDefault(g => g.Codigo.ToString() == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela Categoria Cliente {search} não produziu resultado");
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
