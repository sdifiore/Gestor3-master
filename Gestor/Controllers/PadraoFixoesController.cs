using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("PadroesFixos")]
    public class PadraoFixoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PadraoFixoes
        [Route]
        public ActionResult Index(int? page)
        {
            var model = db.PadroesFixos
                .OrderBy(pf => pf.Descricao);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PadraoFixoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PadraoFixo padraoFixo = db.PadroesFixos.Find(id);
            if (padraoFixo == null)
            {
                return HttpNotFound();
            }
            return View(padraoFixo);
        }

        // GET: PadraoFixoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PadraoFixoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Valor")] PadraoFixo padraoFixo)
        {
            if (ModelState.IsValid)
            {
                db.PadroesFixos.Add(padraoFixo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(padraoFixo);
        }

        // GET: PadraoFixoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PadraoFixo padraoFixo = db.PadroesFixos.Find(id);
            if (padraoFixo == null)
            {
                return HttpNotFound();
            }
            return View(padraoFixo);
        }

        // POST: PadraoFixoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Valor")] PadraoFixo padraoFixo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(padraoFixo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(padraoFixo);
        }

        // GET: PadraoFixoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PadraoFixo padraoFixo = db.PadroesFixos.Find(id);
            if (padraoFixo == null)
            {
                return HttpNotFound();
            }
            return View(padraoFixo);
        }

        // POST: PadraoFixoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PadraoFixo padraoFixo = db.PadroesFixos.Find(id);
            return View("Erase", padraoFixo);
        }

        // POST: PadraoFixoes/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            PadraoFixo padraoFixo = db.PadroesFixos.Find(id);
            db.PadroesFixos.Remove(padraoFixo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(string search)
        {
            var model = db.PadroesFixos
                .FirstOrDefault(g => g.Descricao.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo padrão fixo {search} não produziu resultado");
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
