using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class CuboEstoquesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CuboEstoques
        public ActionResult Index(int? page)
        {
            var cubo = db.CubosEstoque.OrderBy(c => c.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = cubo.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: CuboEstoques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuboEstoque cuboEstoque = db.CubosEstoque.Find(id);
            if (cuboEstoque == null)
            {
                return HttpNotFound();
            }
            return View(cuboEstoque);
        }

        // GET: CuboEstoques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuboEstoques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apelido,Descricao,ClasseCusto,Quantidade")] CuboEstoque cuboEstoque)
        {
            if (ModelState.IsValid)
            {
                db.CubosEstoque.Add(cuboEstoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuboEstoque);
        }

        // GET: CuboEstoques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuboEstoque cuboEstoque = db.CubosEstoque.Find(id);
            if (cuboEstoque == null)
            {
                return HttpNotFound();
            }
            return View(cuboEstoque);
        }

        // POST: CuboEstoques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Descricao,ClasseCusto,Quantidade")] CuboEstoque cuboEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuboEstoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuboEstoque);
        }

        // GET: CuboEstoques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuboEstoque cuboEstoque = db.CubosEstoque.Find(id);
            if (cuboEstoque == null)
            {
                return HttpNotFound();
            }
            return View(cuboEstoque);
        }

        // POST: CuboEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuboEstoque cuboEstoque = db.CubosEstoque.Find(id);
            return View("Erase", cuboEstoque);
        }

        // POST: CuboEstoques/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            CuboEstoque cuboEstoque = db.CubosEstoque.Find(id);
            db.CubosEstoque.Remove(cuboEstoque);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var cubo = db.CubosEstoque.FirstOrDefault(c => c.Apelido == search);

            if (cubo == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo item de cubo de estoque {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", cubo);
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
