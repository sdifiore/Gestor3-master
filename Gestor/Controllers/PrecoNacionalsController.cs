using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("PrecoNacional")]
    public class PrecoNacionalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PrecoNacionals
        [Route]
        public ActionResult Index(int? page)
        {
            var precosNacionais = db.PrecosNacionais
                .Include(p => p.TipoProducao)
                .OrderBy(p => p.Id);

            var pageNumber = page ?? 1;
            var onePageHistory = precosNacionais.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PrecoNacionals/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoNacional precoNacional = db.PrecosNacionais.Find(id);
            if (precoNacional == null)
            {
                return HttpNotFound();
            }
            return View(precoNacional);
        }

        // GET: PrecoNacionals/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.TipoProducaoId = new SelectList(db.TiposProducao, "TipoProducaoId", "Descricao");
            return View();
        }

        // POST: PrecoNacionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LinhaUn,Descricao,Apelido,Ipi,QtUnid,TipoProducaoId,I18Nivel1,I18Nivel2,I18Nivel3,I12Nivel1,I12Nivel2,I12Nivel3,I7Nivel1,I7Nivel2,I7Nivel3,Com,LlMin,PrecoRefer,AplicRoteiro,CustoDireto,RateioCustoFixo,Aumento")] PrecoNacional precoNacional)
        {
            if (ModelState.IsValid)
            {
                db.PrecosNacionais.Add(precoNacional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoProducaoId = new SelectList(db.TiposProducao, "TipoProducaoId", "Descricao", precoNacional.TipoProducaoId);
            return View(precoNacional);
        }

        // GET: PrecoNacionals/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoNacional precoNacional = db.PrecosNacionais.Find(id);
            if (precoNacional == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoProducaoId = new SelectList(db.TiposProducao, "TipoProducaoId", "Descricao", precoNacional.TipoProducaoId);
            return View(precoNacional);
        }

        // POST: PrecoNacionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LinhaUn,Descricao,Apelido,Ipi,QtUnid,TipoProducaoId,I18Nivel1,I18Nivel2,I18Nivel3,I12Nivel1,I12Nivel2,I12Nivel3,I7Nivel1,I7Nivel2,I7Nivel3,Com,LlMin,PrecoRefer,AplicRoteiro,CustoDireto,RateioCustoFixo,Aumento")] PrecoNacional precoNacional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precoNacional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoProducaoId = new SelectList(db.TiposProducao, "TipoProducaoId", "Descricao", precoNacional.TipoProducaoId);
            return View(precoNacional);
        }

        // GET: PrecoNacionals/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoNacional precoNacional = db.PrecosNacionais.Find(id);
            if (precoNacional == null)
            {
                return HttpNotFound();
            }
            return View(precoNacional);
        }

        // POST: PrecoNacionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecoNacional precoNacional = db.PrecosNacionais.Find(id);
            db.PrecosNacionais.Remove(precoNacional);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(string search)
        {
            var precoNacional = db.PrecosNacionais
                .Include(p => p.TipoProducao)
                .SingleOrDefault(p => p.Apelido == search);

            if (precoNacional == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo precoNacional {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", precoNacional);
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
