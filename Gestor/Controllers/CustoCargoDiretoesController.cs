using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("CustoCargos")]
    public class CustoCargoDiretoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustoCargoDiretoes
        [Route]
        public ActionResult Index(int? page)
        {
            var custoCargoDiretos = db.CustoCargoDiretos
                .Include(c => c.Setor)
                .OrderBy(c => c.Setor.Codigo);

            var pageNumber = page ?? 1;
            var onePageHistory = custoCargoDiretos.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: CustoCargoDiretoes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustoCargoDireto custoCargoDireto = db.CustoCargoDiretos
                .Include(c => c.Setor)
                .SingleOrDefault(c => c.Id == id);

            if (custoCargoDireto == null)
            {
                return HttpNotFound();
            }
            return View(custoCargoDireto);
        }

        // GET: CustoCargoDiretoes/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo");
            return View();
        }

        // POST: CustoCargoDiretoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SetorId,Operadores,MoDireta,CodigoLiderApoio,MoDiretaLiderApoio,HorasModOperadores,HorasModTotal,CustoUnitario,RateioSetor20,RateioSetor40,RateioSetor50,RateioSetor60,SomaIndiretos,SomaDiretoIndireto,RateioCustoUnitario")] CustoCargoDireto custoCargoDireto)
        {
            if (ModelState.IsValid)
            {
                db.CustoCargoDiretos.Add(custoCargoDireto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", custoCargoDireto.SetorId);
            return View(custoCargoDireto);
        }

        // GET: CustoCargoDiretoes/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustoCargoDireto custoCargoDireto = db.CustoCargoDiretos.Find(id);
            if (custoCargoDireto == null)
            {
                return HttpNotFound();
            }
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", custoCargoDireto.SetorId);
            return View(custoCargoDireto);
        }

        // POST: CustoCargoDiretoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SetorId,Operadores,MoDireta,CodigoLiderApoio,MoDiretaLiderApoio,HorasModOperadores,HorasModTotal,CustoUnitario,RateioSetor20,RateioSetor40,RateioSetor50,RateioSetor60,SomaIndiretos,SomaDiretoIndireto,RateioCustoUnitario")] CustoCargoDireto custoCargoDireto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custoCargoDireto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", custoCargoDireto.SetorId);
            return View(custoCargoDireto);
        }

        // GET: CustoCargoDiretoes/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustoCargoDireto custoCargoDireto = db.CustoCargoDiretos
                .Include(c => c.Setor)
                .SingleOrDefault(c => c.Id == id);

            if (custoCargoDireto == null)
            {
                return HttpNotFound();
            }
            return View(custoCargoDireto);
        }

        // POST: CustoCargoDiretoes/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustoCargoDireto custoCargoDireto = db.CustoCargoDiretos
                .Include(c => c.Setor)
                .SingleOrDefault(c => c.Id == id);

            return View("Erase", custoCargoDireto);
        }

        // POST: CustoCargoDiretoes/Erase/5
        [HttpPost]
        [Route("Erase")]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            CustoCargoDireto custoCargoDireto = db.CustoCargoDiretos.Find(id);
            db.CustoCargoDiretos.Remove(custoCargoDireto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Search")]
        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.CustoCargoDiretos
                .Include(c => c.Setor)
                .SingleOrDefault(g => g.Setor.Codigo == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Custo Cargo {search} não produziu resultado");
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
