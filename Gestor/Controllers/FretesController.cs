using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class FretesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fretes
        public ActionResult Index(int? page)
        {
            var model = db.Fretes
                        .OrderBy(f => f.FreteId);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Fretes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = db.Fretes.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // GET: Fretes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fretes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FreteId,CifGrandeSp,CifForaGrandeSp,RegioesIcms18,RegioesIcms12,RegioesIcms7,Data")] Frete frete)
        {
            if (ModelState.IsValid)
            {
                frete.CifGrandeSp = frete.CifGrandeSp / 100;
                frete.CifForaGrandeSp = frete.CifForaGrandeSp / 100;
                frete.RegioesIcms18 = frete.RegioesIcms18 / 100;
                frete.RegioesIcms12 = frete.RegioesIcms12 / 100;
                frete.RegioesIcms7 = frete.RegioesIcms7 / 100;

                db.Fretes.Add(frete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frete);
        }

        // GET: Fretes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = db.Fretes.Find(id);

            if (frete == null)
            {
                return HttpNotFound();
            }

            frete.CifGrandeSp = frete.CifGrandeSp * 100;
            frete.CifForaGrandeSp = frete.CifForaGrandeSp * 100;
            frete.RegioesIcms18 = frete.RegioesIcms18 * 100;
            frete.RegioesIcms12 = frete.RegioesIcms12 * 100;
            frete.RegioesIcms7 = frete.RegioesIcms7 * 100;

            return View(frete);
        }

        // POST: Fretes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FreteId,CifGrandeSp,CifForaGrandeSp,RegioesIcms18,RegioesIcms12,RegioesIcms7,Data")] Frete frete)
        {
            if (ModelState.IsValid)
            {
                frete.CifGrandeSp = frete.CifGrandeSp / 100;
                frete.CifForaGrandeSp = frete.CifForaGrandeSp / 100;
                frete.RegioesIcms18 = frete.RegioesIcms18 / 100;
                frete.RegioesIcms12 = frete.RegioesIcms12 / 100;
                frete.RegioesIcms7 = frete.RegioesIcms7 / 100;

                db.Entry(frete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frete);
        }

        // GET: Fretes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = db.Fretes.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // POST: Fretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frete frete = db.Fretes.Find(id);
            db.Fretes.Remove(frete);
            db.SaveChanges();
            return RedirectToAction("Index");
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
