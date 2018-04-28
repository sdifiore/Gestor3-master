// Custo_3.PlanejVendas

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class TiposVendaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TiposVenda
        public ActionResult Index(int? page)
        {
            var model = db.TiposVenda
                        .OrderBy(t => t.Tipo);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: TiposVenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVenda tipoVenda = db.TiposVenda.Find(id);
            if (tipoVenda == null)
            {
                return HttpNotFound();
            }
            return View(tipoVenda);
        }

        // GET: TiposVenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposVenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Descricao")] TipoVenda tipoVenda)
        {
            if (ModelState.IsValid)
            {
                db.TiposVenda.Add(tipoVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoVenda);
        }

        // GET: TiposVenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVenda tipoVenda = db.TiposVenda.Find(id);
            if (tipoVenda == null)
            {
                return HttpNotFound();
            }
            return View(tipoVenda);
        }

        // POST: TiposVenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Descricao")] TipoVenda tipoVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoVenda);
        }

        // GET: TiposVenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVenda tipoVenda = db.TiposVenda.Find(id);
            if (tipoVenda == null)
            {
                return HttpNotFound();
            }
            return View(tipoVenda);
        }

        // POST: TiposVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoVenda tipoVenda = db.TiposVenda.Find(id);
            db.TiposVenda.Remove(tipoVenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.TiposVenda
                .FirstOrDefault(g => g.Tipo.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo tipo de venda {search} não produziu resultado");
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
