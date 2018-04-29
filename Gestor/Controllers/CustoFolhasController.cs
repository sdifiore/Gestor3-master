using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class CustoFolhasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustoFolhas
        public ActionResult Index(int? page)
        {
            var custoFolhas = db.CustoFolhas
                .Include(c => c.Area)
                .OrderBy(c => c.Area.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = custoFolhas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: CustoFolhas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustoFolha custoFolha = db.CustoFolhas.Include(c => c.Area).SingleOrDefault(c => c.CustoFolhaId == id);
            if (custoFolha == null)
            {
                return HttpNotFound();
            }
            return View(custoFolha);
        }

        // GET: CustoFolhas/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Apelido");
            return View();
        }

        // POST: CustoFolhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustoFolhaId,Data,Salario,Ferias,DecimoTerceiro,Plr,Fgts,Inss,DespAgencia,ConvMedico,VAlimentacao,VTransporte,AreaId")] CustoFolha custoFolha)
        {
            if (ModelState.IsValid)
            {
                db.CustoFolhas.Add(custoFolha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Apelido", custoFolha.AreaId);
            return View(custoFolha);
        }

        // GET: CustoFolhas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustoFolha custoFolha = db.CustoFolhas.Find(id);
            if (custoFolha == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Apelido", custoFolha.AreaId);
            return View(custoFolha);
        }

        // POST: CustoFolhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustoFolhaId,Data,Salario,Ferias,DecimoTerceiro,Plr,Fgts,Inss,DespAgencia,ConvMedico,VAlimentacao,VTransporte,AreaId")] CustoFolha custoFolha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custoFolha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Apelido", custoFolha.AreaId);
            return View(custoFolha);
        }

        // GET: CustoFolhas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustoFolha custoFolha = db.CustoFolhas.Include(c => c.Area).SingleOrDefault(c => c.CustoFolhaId == id);
            if (custoFolha == null)
            {
                return HttpNotFound();
            }
            return View(custoFolha);
        }

        // POST: CustoFolhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustoFolha custoFolha = db.CustoFolhas.Find(id);
            return View("Erase", custoFolha);
        }

        // POST: CustoFolhas/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            CustoFolha custoFolha = db.CustoFolhas.Find(id);
            db.CustoFolhas.Remove(custoFolha);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.CustoFolhas
                .Include(c => c.Area)
                .SingleOrDefault(g => g.Area.Nome == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Custo Folha {search} não produziu resultado");
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
