// Custo_3.PlanejVendas

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class SequenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sequencias
        public ActionResult Index(int? page)
        {
            var model = db.Sequencias
                        .OrderBy(s => s.Tipo);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Sequencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sequencia sequencia = db.Sequencias.Find(id);
            if (sequencia == null)
            {
                return HttpNotFound();
            }
            return View(sequencia);
        }

        // GET: Sequencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sequencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SequenciaId,Tipo,Descricao")] Sequencia sequencia)
        {
            if (ModelState.IsValid)
            {
                db.Sequencias.Add(sequencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sequencia);
        }

        // GET: Sequencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sequencia sequencia = db.Sequencias.Find(id);
            if (sequencia == null)
            {
                return HttpNotFound();
            }
            return View(sequencia);
        }

        // POST: Sequencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SequenciaId,Tipo,Descricao")] Sequencia sequencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sequencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sequencia);
        }

        // GET: Sequencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sequencia sequencia = db.Sequencias.Find(id);
            if (sequencia == null)
            {
                return HttpNotFound();
            }
            return View(sequencia);
        }

        // POST: Sequencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sequencia sequencia = db.Sequencias.Find(id);
            db.Sequencias.Remove(sequencia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Sequencias
                .FirstOrDefault(g => g.Tipo.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela Sequência {search} não produziu resultado");
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
