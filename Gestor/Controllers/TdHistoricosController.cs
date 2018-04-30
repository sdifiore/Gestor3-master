// Custo_3.PlanejVendas

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class TdHistoricosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TdHistoricos
        public ActionResult Index(int? page)
        {
            var model = db.TdHistoricos
                        .OrderBy(t => t.Totalizador);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: TdHistoricos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TdHistorico tdHistorico = db.TdHistoricos.Find(id);
            if (tdHistorico == null)
            {
                return HttpNotFound();
            }
            return View(tdHistorico);
        }

        // GET: TdHistoricos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TdHistoricos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Totalizador,PropRecLiq,PropPeso,PropHoras,PropQuant,TercRecLiq,TercPeso,TercHoras,TercQuant")] TdHistorico tdHistorico)
        {
            if (ModelState.IsValid)
            {
                db.TdHistoricos.Add(tdHistorico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tdHistorico);
        }

        // GET: TdHistoricos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TdHistorico tdHistorico = db.TdHistoricos.Find(id);
            if (tdHistorico == null)
            {
                return HttpNotFound();
            }
            return View(tdHistorico);
        }

        // POST: TdHistoricos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Totalizador,PropRecLiq,PropPeso,PropHoras,PropQuant,TercRecLiq,TercPeso,TercHoras,TercQuant")] TdHistorico tdHistorico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tdHistorico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tdHistorico);
        }

        // GET: TdHistoricos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TdHistorico tdHistorico = db.TdHistoricos.Find(id);
            if (tdHistorico == null)
            {
                return HttpNotFound();
            }
            return View(tdHistorico);
        }

        // POST: TdHistoricos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TdHistorico tdHistorico = db.TdHistoricos.Find(id);
            return View("Erase", tdHistorico);
        }

        // POST: TdHistoricos/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            TdHistorico tdHistorico = db.TdHistoricos.Find(id);
            db.TdHistoricos.Remove(tdHistorico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.TdHistoricos
                .FirstOrDefault(g => g.Totalizador.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo TDHistórico {search} não produziu resultado");
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
