using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("Parametros")]
    public class ParametroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parametroes
        [Route]
        public ActionResult Index(int? page)
        {
            var model = db.Parametros
                        .OrderBy(p => p.Id);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Parametroes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametro parametro = db.Parametros.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            return View(parametro);
        }

        // GET: Parametroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parametroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dolar,PropFitasFioGaxeta,PropSucatas,PropGrafitado,HMod,CustoFixoIndustrialAno,CustoFixoComercialAno,CustoFixoComtexAno,CustoFixoAdminAno,ComissaoGcComacs,Icms,Ipi,Inss,Comissão,Frete,MargemLiquida,ComissGestVenda,CondicaoPgtoStd,TxJuroStd,CustoFin,CustoCobranca")] Parametro parametro)
        {
            if (ModelState.IsValid)
            {
                db.Parametros.Add(parametro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parametro);
        }

        // GET: Parametroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametro parametro = db.Parametros.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }

            parametro.PropFitasFioGaxeta = parametro.PropFitasFioGaxeta * 100;
            parametro.PropSucatas = parametro.PropSucatas * 100;
            parametro.PropGrafitado = parametro.PropGrafitado * 100;
            parametro.Icms = parametro.Icms * 100;
            parametro.Ipi = parametro.Ipi * 100;
            parametro.Inss = parametro.Inss * 100;
            parametro.Comissão = parametro.Comissão * 100;
            parametro.Frete = parametro.Frete * 100;
            parametro.MargemLiquida = parametro.MargemLiquida * 100;
            parametro.ComissGestVenda = parametro.ComissGestVenda * 100;
            parametro.TxJuroStd = parametro.TxJuroStd * 100;
            parametro.CustoFin = parametro.CustoFin * 100;
            parametro.CustoCobranca = parametro.CustoCobranca * 100;

            return View(parametro);
        }

        // POST: Parametroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dolar,PropFitasFioGaxeta,PropSucatas,PropGrafitado,HMod,CustoFixoIndustrialAno,CustoFixoComercialAno,CustoFixoComtexAno,CustoFixoAdminAno,ComissaoGcComacs,Icms,Ipi,Inss,Comissão,Frete,MargemLiquida,ComissGestVenda,CondicaoPgtoStd,TxJuroStd,CustoFin,CustoCobranca")] Parametro parametro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parametro).State = EntityState.Modified;

                parametro.PropFitasFioGaxeta = parametro.PropFitasFioGaxeta / 100;
                parametro.PropSucatas = parametro.PropSucatas / 100;
                parametro.PropGrafitado = parametro.PropGrafitado / 100;
                parametro.Icms = parametro.Icms / 100;
                parametro.Ipi = parametro.Ipi / 100;
                parametro.Inss = parametro.Inss / 100;
                parametro.Comissão = parametro.Comissão / 100;
                parametro.Frete = parametro.Frete / 100;
                parametro.MargemLiquida = parametro.MargemLiquida / 100;
                parametro.ComissGestVenda = parametro.ComissGestVenda / 100;
                parametro.TxJuroStd = parametro.TxJuroStd / 100;
                parametro.CustoFin = parametro.CustoFin / 100;
                parametro.CustoCobranca = parametro.CustoCobranca / 100;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parametro);
        }

        // GET: Parametroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametro parametro = db.Parametros.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            return View(parametro);
        }

        // POST: Parametroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parametro parametro = db.Parametros.Find(id);
            db.Parametros.Remove(parametro);
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
