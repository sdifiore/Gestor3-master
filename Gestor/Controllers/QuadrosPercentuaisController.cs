// Custo_3.PlanejVendas

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class QuadrosPercentuaisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuadrosPercentuais
        public ActionResult Index(int? page)
        {
            var model = db.QuadrosPercentuais.OrderBy(q => q.Id);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: QuadrosPercentuais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuadroPercentual quadroPercentual = db.QuadrosPercentuais.Find(id);
            if (quadroPercentual == null)
            {
                return HttpNotFound();
            }
            return View(quadroPercentual);
        }

        // GET: QuadrosPercentuais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuadrosPercentuais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RlGlobalFita,RlGlobalTubo,RlGlobalFiotec,RlGlobalGxpuro,RlGlobalGxgraf,RlGlobalGraxa,RlGlobalRevenda,RlPropriaFita,RlPropriaTubo,RlPropriaFiotec,RlPropriaGxpuro,RlPropriaGxgraf,RlPropriaGraxa,RlPropriaRevenda,RlTerceirosFita,RlTerceirosTubo,RlTerceirosFiotec,RlTerceirosGxpuro,RlTerceirosGxgraf,RlTerceirosGraxa,RlTerceirosRevenda,PlGlobalFita,PlGlobalTubo,PlGlobalFiotec,PlGlobalGxpuro,PlGlobalGxgraf,PlGlobalGraxa,PlGlobalRevenda,PlPropriaFita,PlPropriaTubo,PlPropriaFiotec,PlPropriaGxpuro,PlPropriaGxgraf,PlPropriaGraxa,PlPropriaRevenda,PlTerceirosFita,PlTerceirosTubo,PlTerceirosFiotec,PlTerceirosGxpuro,PlTerceirosGxgraf,PlTerceirosGraxa,PlTerceirosRevenda,HmGlobalFita,HmGlobalTubo,HmGlobalFiotec,HmGlobalGxpuro,HmGlobalGxgraf,HmGlobalGraxa,HmGlobalRevenda,HmPropriaFita,HmPropriaTubo,HmPropriaFiotec,HmPropriaGxpuro,HmPropriaGxgraf,HmPropriaGraxa,HmPropriaRevenda,HmTerceirosFita,HmTerceirosTubo,HmTerceirosFiotec,HmTerceirosGxpuro,HmTerceirosGxgraf,HmTerceirosGraxa,HmTerceirosRevenda,QipGloballFita,QipGloballTubo,QipGloballFiotec,QipGloballGxpuro,QipGloballGxgraf,QipGloballGraxa,QipGloballRevenda,QipPropriaFita,QipPropriaTubo,QipPropriaFiotec,QipPropriaGxpuro,QipPropriaGxgraf,QipPropriaGraxa,QipPropriaRevenda,QipTerceirosFita,QipTerceirosTubo,QipTerceirosFiotec,QipTerceirosGxpuro,QipTerceirosGxgraf,QipTerceirosGraxa,QipTerceirosRevenda")] QuadroPercentual quadroPercentual)
        {
            if (ModelState.IsValid)
            {
                db.QuadrosPercentuais.Add(quadroPercentual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quadroPercentual);
        }

        // GET: QuadrosPercentuais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuadroPercentual quadroPercentual = db.QuadrosPercentuais.Find(id);
            if (quadroPercentual == null)
            {
                return HttpNotFound();
            }
            return View(quadroPercentual);
        }

        // POST: QuadrosPercentuais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RlGlobalFita,RlGlobalTubo,RlGlobalFiotec,RlGlobalGxpuro,RlGlobalGxgraf,RlGlobalGraxa,RlGlobalRevenda,RlPropriaFita,RlPropriaTubo,RlPropriaFiotec,RlPropriaGxpuro,RlPropriaGxgraf,RlPropriaGraxa,RlPropriaRevenda,RlTerceirosFita,RlTerceirosTubo,RlTerceirosFiotec,RlTerceirosGxpuro,RlTerceirosGxgraf,RlTerceirosGraxa,RlTerceirosRevenda,PlGlobalFita,PlGlobalTubo,PlGlobalFiotec,PlGlobalGxpuro,PlGlobalGxgraf,PlGlobalGraxa,PlGlobalRevenda,PlPropriaFita,PlPropriaTubo,PlPropriaFiotec,PlPropriaGxpuro,PlPropriaGxgraf,PlPropriaGraxa,PlPropriaRevenda,PlTerceirosFita,PlTerceirosTubo,PlTerceirosFiotec,PlTerceirosGxpuro,PlTerceirosGxgraf,PlTerceirosGraxa,PlTerceirosRevenda,HmGlobalFita,HmGlobalTubo,HmGlobalFiotec,HmGlobalGxpuro,HmGlobalGxgraf,HmGlobalGraxa,HmGlobalRevenda,HmPropriaFita,HmPropriaTubo,HmPropriaFiotec,HmPropriaGxpuro,HmPropriaGxgraf,HmPropriaGraxa,HmPropriaRevenda,HmTerceirosFita,HmTerceirosTubo,HmTerceirosFiotec,HmTerceirosGxpuro,HmTerceirosGxgraf,HmTerceirosGraxa,HmTerceirosRevenda,QipGloballFita,QipGloballTubo,QipGloballFiotec,QipGloballGxpuro,QipGloballGxgraf,QipGloballGraxa,QipGloballRevenda,QipPropriaFita,QipPropriaTubo,QipPropriaFiotec,QipPropriaGxpuro,QipPropriaGxgraf,QipPropriaGraxa,QipPropriaRevenda,QipTerceirosFita,QipTerceirosTubo,QipTerceirosFiotec,QipTerceirosGxpuro,QipTerceirosGxgraf,QipTerceirosGraxa,QipTerceirosRevenda")] QuadroPercentual quadroPercentual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quadroPercentual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quadroPercentual);
        }

        // GET: QuadrosPercentuais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuadroPercentual quadroPercentual = db.QuadrosPercentuais.Find(id);
            if (quadroPercentual == null)
            {
                return HttpNotFound();
            }
            return View(quadroPercentual);
        }

        // POST: QuadrosPercentuais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuadroPercentual quadroPercentual = db.QuadrosPercentuais.Find(id);
            db.QuadrosPercentuais.Remove(quadroPercentual);
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
