using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class IcmsFretesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IcmsFretes
        public ActionResult Index(int? page)
        {
            var model = db.IcmsFretes
                        .OrderBy(i => i.Rotulo);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: IcmsFretes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmsFrete icmsFrete = db.IcmsFretes.Find(id);
            if (icmsFrete == null)
            {
                return HttpNotFound();
            }
            return View(icmsFrete);
        }

        // GET: IcmsFretes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IcmsFretes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rotulo,Icms,Frete")] IcmsFrete icmsFrete)
        {
            if (ModelState.IsValid)
            {
                db.IcmsFretes.Add(icmsFrete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(icmsFrete);
        }

        // GET: IcmsFretes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmsFrete icmsFrete = db.IcmsFretes.Find(id);
            if (icmsFrete == null)
            {
                return HttpNotFound();
            }
            return View(icmsFrete);
        }

        // POST: IcmsFretes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rotulo,Icms,Frete")] IcmsFrete icmsFrete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icmsFrete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(icmsFrete);
        }

        // GET: IcmsFretes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IcmsFrete icmsFrete = db.IcmsFretes.Find(id);
            if (icmsFrete == null)
            {
                return HttpNotFound();
            }
            return View(icmsFrete);
        }

        // POST: IcmsFretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IcmsFrete icmsFrete = db.IcmsFretes.Find(id);
            return View("Erase", icmsFrete);
        }

        // POST: IcmsFretes/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            IcmsFrete icmsFrete = db.IcmsFretes.Find(id);
            db.IcmsFretes.Remove(icmsFrete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.IcmsFretes
                .SingleOrDefault(g => g.Rotulo == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo ICMS Frete {search} não produziu resultado");
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
