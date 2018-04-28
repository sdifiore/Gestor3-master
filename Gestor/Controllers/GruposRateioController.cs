// Custo_3.PlanejVendas

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class GruposRateioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GruposRateio
        public ActionResult Index(int? page)
        {
            var model = db.GruposRateio
                        .OrderBy(g => g.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = model.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: GruposRateio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoRateio grupoRateio = db.GruposRateio.Find(id);
            if (grupoRateio == null)
            {
                return HttpNotFound();
            }
            return View(grupoRateio);
        }

        // GET: GruposRateio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GruposRateio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupoRateioId,Apelido,Descricao,Fita,Tubo,Fiotec,Gxpuro,Gxgraf,Graxa,Revenda")] GrupoRateio grupoRateio)
        {
            if (ModelState.IsValid)
            {
                db.GruposRateio.Add(grupoRateio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoRateio);
        }

        // GET: GruposRateio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoRateio grupoRateio = db.GruposRateio.Find(id);
            if (grupoRateio == null)
            {
                return HttpNotFound();
            }
            return View(grupoRateio);
        }

        // POST: GruposRateio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrupoRateioId,Apelido,Descricao,Fita,Tubo,Fiotec,Gxpuro,Gxgraf,Graxa,Revenda")] GrupoRateio grupoRateio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoRateio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoRateio);
        }

        // GET: GruposRateio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoRateio grupoRateio = db.GruposRateio.Find(id);
            if (grupoRateio == null)
            {
                return HttpNotFound();
            }
            return View(grupoRateio);
        }

        // POST: GruposRateio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoRateio grupoRateio = db.GruposRateio.Find(id);
            db.GruposRateio.Remove(grupoRateio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Graxa()
        {
            var model = db.GruposRateio.SingleOrDefault(g => g.Apelido == "GR0005");
            if (model == null)
            {
                DbLogger.Log(Reason.Error, "GrupoRateioControler.Graxa: Não encontrado Apelido = GR0005");
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Graxa(GrupoRateio grupoRateio)
        {
            var gr5 = db.GruposRateio.SingleOrDefault(g => g.Apelido == "GR0005");
            gr5.Graxa = grupoRateio.Graxa;
            db.SaveChanges();
            Populate.GrupoRateio();

            return RedirectToAction("Index");
        }

        public ActionResult Taxa()
        {
            var model = db.GruposRateio.SingleOrDefault(g => g.Apelido == "GR0009");
            if (model == null)
            {
                DbLogger.Log(Reason.Error, "GrupoRateioControler.Taxa: Não encontrado Apelido = GR0009");
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }

            model.Fita = model.Fita * 100;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Taxa(GrupoRateio grupoRateio)
        {
            var gr9 = db.GruposRateio.SingleOrDefault(g => g.Apelido == "GR0009");
            gr9.Fita = grupoRateio.Fita / 100;
            gr9.Tubo = gr9.Fita;
            gr9.Fiotec = gr9.Fita;
            gr9.Gxpuro = gr9.Fita;
            gr9.Gxgraf = gr9.Fita;
            gr9.Graxa = gr9.Fita;
            gr9.Revenda = gr9.Fita;
            db.SaveChanges();
            Populate.GrupoRateio();

            return RedirectToAction("Index");
        }

        public ActionResult Distribuicao()
        {
            var model = db.GruposRateio.SingleOrDefault(g => g.Apelido == "GR0013");
            if (model == null)
            {
                DbLogger.Log(Reason.Error, "GrupoRateioControler.Distribuicao: Não encontrado Apelido = GR0013");
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Distribuicao(GrupoRateio grupoRateio)
        {
            var gr13 = db.GruposRateio.SingleOrDefault(g => g.Apelido == "GR0013");
            gr13.Fita = grupoRateio.Fita;
            gr13.Tubo = grupoRateio.Tubo;
            gr13.Fiotec = grupoRateio.Fiotec;
            gr13.Gxpuro = grupoRateio.Gxpuro;
            gr13.Gxgraf = grupoRateio.Gxgraf;
            gr13.Graxa = grupoRateio.Graxa;
            gr13.Revenda = grupoRateio.Revenda;
            db.SaveChanges();
            Populate.GrupoRateio();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.GruposRateio
                .SingleOrDefault(g => g.Apelido == search);

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo grupo de rateio {search} não produziu resultado");
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
