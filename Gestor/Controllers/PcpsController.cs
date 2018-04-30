using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class PcpsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pcps
        public ActionResult Index(int? page)
        {
            var model = db.Pcps
                        .OrderBy(p => p.Descricao);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Pcps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pcp pcp = db.Pcps.Find(id);
            if (pcp == null)
            {
                return HttpNotFound();
            }
            return View(pcp);
        }

        // GET: Pcps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pcps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PcpId,Descricao")] Pcp pcp)
        {
            if (ModelState.IsValid)
            {
                db.Pcps.Add(pcp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pcp);
        }

        // GET: Pcps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pcp pcp = db.Pcps.Find(id);
            if (pcp == null)
            {
                return HttpNotFound();
            }
            return View(pcp);
        }

        // POST: Pcps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PcpId,Descricao")] Pcp pcp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pcp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pcp);
        }

        // GET: Pcps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pcp pcp = db.Pcps.Find(id);
            if (pcp == null)
            {
                return HttpNotFound();
            }
            return View(pcp);
        }

        // POST: Pcps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pcp pcp = db.Pcps.Find(id);
            return View("Erase", pcp);
        }

        // POST: Pcps/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Pcp pcp = db.Pcps.Find(id);
            db.Pcps.Remove(pcp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Pcps
                .SingleOrDefault(g => g.Descricao.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo PCP {search} não produziu resultado");
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
