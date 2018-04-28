using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("PrecosExportacao")]
    public class PrecoExportacaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PrecoExportacaos
        [Route]
        public ActionResult Index(int? page)
        {
            var precosExpostacao = db.PrecosExpostacao
                .Include(p => p.CondicaoPreco)
                .OrderBy(p => p.Id);

            var pageNumber = page ?? 1;
            var onePageHistory = precosExpostacao.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PrecoExportacaos/Details/5
        [Route("Detail")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoExportacao precoExportacao = db.PrecosExpostacao.Find(id);
            if (precoExportacao == null)
            {
                return HttpNotFound();
            }
            return View(precoExportacao);
        }

        // GET: PrecoExportacaos/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.CondicaoPrecoId = new SelectList(db.CondicoesPrecos, "Id", "Apelido");
            return View();
        }

        // POST: PrecoExportacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LinhaUn,Descricao,Apelido,PesoLiquido,QtUnid,De2A5,De5A10,De10A20,Acima20,Com,LlMin,CondicaoPrecoId,PctRateio,CondPag,IEfetiva,PctEspecFrete,DespExpPadrao,PctDespExportEspec,PvFobMax,CustoDireto,RateioCustoFixo,PvFobMin,ValorCifPtfe,RelPtfeSobrePv")] PrecoExportacao precoExportacao)
        {
            if (ModelState.IsValid)
            {
                db.PrecosExpostacao.Add(precoExportacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondicaoPrecoId = new SelectList(db.CondicoesPrecos, "Id", "Apelido", precoExportacao.CondicaoPrecoId);
            return View(precoExportacao);
        }

        // GET: PrecoExportacaos/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoExportacao precoExportacao = db.PrecosExpostacao.Find(id);
            if (precoExportacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondicaoPrecoId = new SelectList(db.CondicoesPrecos, "Id", "Apelido", precoExportacao.CondicaoPrecoId);
            return View(precoExportacao);
        }

        // POST: PrecoExportacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LinhaUn,Descricao,Apelido,PesoLiquido,QtUnid,De2A5,De5A10,De10A20,Acima20,Com,LlMin,CondicaoPrecoId,PctRateio,CondPag,IEfetiva,PctEspecFrete,DespExpPadrao,PctDespExportEspec,PvFobMax,CustoDireto,RateioCustoFixo,PvFobMin,ValorCifPtfe,RelPtfeSobrePv")] PrecoExportacao precoExportacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precoExportacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondicaoPrecoId = new SelectList(db.CondicoesPrecos, "Id", "Apelido", precoExportacao.CondicaoPrecoId);
            return View(precoExportacao);
        }

        // GET: PrecoExportacaos/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoExportacao precoExportacao = db.PrecosExpostacao.Find(id);
            if (precoExportacao == null)
            {
                return HttpNotFound();
            }
            return View(precoExportacao);
        }

        // POST: PrecoExportacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecoExportacao precoExportacao = db.PrecosExpostacao.Find(id);
            db.PrecosExpostacao.Remove(precoExportacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var precoExpostacao = db.PrecosExpostacao
                .Include(p => p.CondicaoPreco)
                .SingleOrDefault(p => p.Apelido == search);

            if (precoExpostacao == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo precoExpostacao {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", precoExpostacao);
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
