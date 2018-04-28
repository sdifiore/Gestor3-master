using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;

namespace Gestor.Controllers
{
    [RoutePrefix("CondicoesPrecos")]
    public class CondicaoPrecoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CondicaoPrecoes
        [Route]
        public ActionResult Index()
        {
            return View(db.CondicoesPrecos.ToList());
        }

        // GET: CondicaoPrecoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicaoPreco condicaoPreco = db.CondicoesPrecos.Find(id);
            if (condicaoPreco == null)
            {
                return HttpNotFound();
            }
            return View(condicaoPreco);
        }

        // GET: CondicaoPrecoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicaoPrecoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apelido,Descricao")] CondicaoPreco condicaoPreco)
        {
            if (ModelState.IsValid)
            {
                db.CondicoesPrecos.Add(condicaoPreco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicaoPreco);
        }

        // GET: CondicaoPrecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicaoPreco condicaoPreco = db.CondicoesPrecos.Find(id);
            if (condicaoPreco == null)
            {
                return HttpNotFound();
            }
            return View(condicaoPreco);
        }

        // POST: CondicaoPrecoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Descricao")] CondicaoPreco condicaoPreco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicaoPreco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicaoPreco);
        }

        // GET: CondicaoPrecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicaoPreco condicaoPreco = db.CondicoesPrecos.Find(id);
            if (condicaoPreco == null)
            {
                return HttpNotFound();
            }
            return View(condicaoPreco);
        }

        // POST: CondicaoPrecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondicaoPreco condicaoPreco = db.CondicoesPrecos.Find(id);
            db.CondicoesPrecos.Remove(condicaoPreco);
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
