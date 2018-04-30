// Custo_3.PlanejVendas

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class TiposClienteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TiposCliente
        public ActionResult Index(int? page)
        {
            var model = db.TiposCliente
                        .OrderBy(t => t.Codigo);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: TiposCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCliente tipoCliente = db.TiposCliente.Find(id);
            if (tipoCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoCliente);
        }

        // GET: TiposCliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nome,Descricao")] TipoCliente tipoCliente)
        {
            if (ModelState.IsValid)
            {
                db.TiposCliente.Add(tipoCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCliente);
        }

        // GET: TiposCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCliente tipoCliente = db.TiposCliente.Find(id);
            if (tipoCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoCliente);
        }

        // POST: TiposCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nome,Descricao")] TipoCliente tipoCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCliente);
        }

        // GET: TiposCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCliente tipoCliente = db.TiposCliente.Find(id);
            if (tipoCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoCliente);
        }

        // POST: TiposCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCliente tipoCliente = db.TiposCliente.Find(id);
            return View("Erase", tipoCliente);
        }

        // POST: TiposCliente/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            TipoCliente tipoCliente = db.TiposCliente.Find(id);
            db.TiposCliente.Remove(tipoCliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.TiposCliente
                .FirstOrDefault(g => g.Codigo.ToString() == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Tipo de Cliente {search} não produziu resultado");
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
