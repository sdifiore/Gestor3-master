using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class FamiliasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Familias
        public ActionResult Index(int? page)
        {
            var model = db.Familias
                        .OrderBy(f => f.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Familias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia familia = db.Familias.Find(id);
            if (familia == null)
            {
                return HttpNotFound();
            }
            return View(familia);
        }

        // GET: Familias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Familias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamiliaId,Apelido,Descricao")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                db.Familias.Add(familia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familia);
        }

        // GET: Familias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia familia = db.Familias.Find(id);
            if (familia == null)
            {
                return HttpNotFound();
            }
            return View(familia);
        }

        // POST: Familias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamiliaId,Apelido,Descricao")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familia);
        }

        // GET: Familias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia familia = db.Familias.Find(id);
            if (familia == null)
            {
                return HttpNotFound();
            }
            return View(familia);
        }

        // POST: Familias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Familia familia = db.Familias.Find(id);
            return View("Erase", familia);
        }

        // POST: Familias/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            try
            {
                Familia familia = db.Familias.Find(id);
                db.Familias.Remove(familia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                DbLogger.Log(Reason.Atention, $"Tentativa de eliminar Família id {id} existindo PlanejProducao associado: {ex.Message} -- {ex.InnerException}");
                return Content("Não é possível eliminar pois existe um PlanejProducao associado a essa Família.");
            }

            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, $"Erro ao tentar eliminar Família Id {id}: {ex.Message} -- {ex.InnerException}");
                return Content("Domínio não eliminado devido a erro. Tente novamente ou notifique suporte.");
            }
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Familias
                .SingleOrDefault(g => g.Apelido == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pela família {search} não produziu resultado");
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
