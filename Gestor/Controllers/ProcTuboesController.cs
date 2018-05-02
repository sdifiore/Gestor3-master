using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    [RoutePrefix("ProcTubos")]
    public class ProcTuboesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProcTuboes
        [Route]
        public ActionResult Index(int? page)
        {
            var procTubos = db.ProcTubos
                .Include(p => p.Carga1)
                .Include(p => p.Carga2)
                .Include(p => p.Embalagem)
                .Include(p => p.Produto)
                .Include(p => p.ResinaBase)
                .Include(p => p.Serie)
                .OrderBy(p => p.Produto.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = procTubos.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: ProcTuboes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var procTubo = db.ProcTubos
                .Include(p => p.Carga1)
                .Include(p => p.Carga2)
                .Include(p => p.Embalagem)
                .Include(p => p.Produto)
                .Include(p => p.ResinaBase)
                .Include(p => p.Serie)
                .SingleOrDefault(p => p.Id == id);

            if (procTubo == null)
            {
                return HttpNotFound();
            }
            return View(procTubo);
        }

        // GET: ProcTuboes/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.Carga1Id = new SelectList(db.Cargas, "Id", "Apelido");
            ViewBag.Carga2Id = new SelectList(db.Cargas, "Id", "Apelido");
            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido");
            ViewBag.SerieId = new SelectList(db.Series, "Id", "Apelido");
            return View();
        }

        // POST: ProcTuboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,ResinaBaseId,DiamExterno,DiamInterno,SerieId,Carga1Id,PctCarga1,Carga2Id,PctCarga2,Sinterizado,CodResinaAdotada,RrMaxResina,BicoIdeal,MandrilIdeal,SecaoExtrudado,PerimSecaoExtrud,DiamExtFinalTubo,DiamIntFinalTubo,PesoUnKgMLiq,PtfeKgM,LubrKgM,CodPreformaIdeal,Rr,LanceSinterizado,FatorMultiplQtde,QtPf,EmbalagemId,QuantEmbalagem,ProcessoContinuo,VextrUmidoMin,FatorMultiplVExter,VsintMMin,FatorMultiplVelSint,VSintResultante,TesteEstqEsto,ConfAdtDosLub,Peneiramento,MisturaMinM,PreparoExtrusMinM,VelEfetExtrusaoMMin,TuSinterizadoMinM,TuProducaoMinM,TuInspUdc3MinM,TuTesteEstanqMinM,TuTesteEstouroMinM,TuEmbalMinM,TuTotalMinM,CustoPtfeRsM,CustoAditivosRsM,CustoLubrifRsM,CustoEmbalRsM,CustoModRsM,CustoDiretoTotalRsM,CustoIndiretoRsM,CustoTotalRsM,PvRsKg,CapProducaoMH,QtPCusto,PvCalculadoRsM")] ProcTubo procTubo)
        {
            if (ModelState.IsValid)
            {
                db.ProcTubos.Add(procTubo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Carga1Id = new SelectList(db.Cargas, "Id", "Apelido", procTubo.Carga1Id);
            ViewBag.Carga2Id = new SelectList(db.Cargas, "Id", "Apelido", procTubo.Carga2Id);
            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla", procTubo.EmbalagemId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", procTubo.ProdutoId);
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido", procTubo.ResinaBaseId);
            ViewBag.SerieId = new SelectList(db.Series, "Id", "Apelido", procTubo.SerieId);
            return View(procTubo);
        }

        // GET: ProcTuboes/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcTubo procTubo = db.ProcTubos.Find(id);
            if (procTubo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Carga1Id = new SelectList(db.Cargas, "Id", "Apelido", procTubo.Carga1Id);
            ViewBag.Carga2Id = new SelectList(db.Cargas, "Id", "Apelido", procTubo.Carga2Id);
            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla", procTubo.EmbalagemId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", procTubo.ProdutoId);
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido", procTubo.ResinaBaseId);
            ViewBag.SerieId = new SelectList(db.Series, "Id", "Apelido", procTubo.SerieId);
            return View(procTubo);
        }

        // POST: ProcTuboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,ResinaBaseId,DiamExterno,DiamInterno,SerieId,Carga1Id,PctCarga1,Carga2Id,PctCarga2,Sinterizado,CodResinaAdotada,RrMaxResina,BicoIdeal,MandrilIdeal,SecaoExtrudado,PerimSecaoExtrud,DiamExtFinalTubo,DiamIntFinalTubo,PesoUnKgMLiq,PtfeKgM,LubrKgM,CodPreformaIdeal,Rr,LanceSinterizado,FatorMultiplQtde,QtPf,EmbalagemId,QuantEmbalagem,ProcessoContinuo,VextrUmidoMin,FatorMultiplVExter,VsintMMin,FatorMultiplVelSint,VSintResultante,TesteEstqEsto,ConfAdtDosLub,Peneiramento,MisturaMinM,PreparoExtrusMinM,VelEfetExtrusaoMMin,TuSinterizadoMinM,TuProducaoMinM,TuInspUdc3MinM,TuTesteEstanqMinM,TuTesteEstouroMinM,TuEmbalMinM,TuTotalMinM,CustoPtfeRsM,CustoAditivosRsM,CustoLubrifRsM,CustoEmbalRsM,CustoModRsM,CustoDiretoTotalRsM,CustoIndiretoRsM,CustoTotalRsM,PvRsKg,CapProducaoMH,QtPCusto,PvCalculadoRsM")] ProcTubo procTubo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procTubo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Carga1Id = new SelectList(db.Cargas, "Id", "Apelido", procTubo.Carga1Id);
            ViewBag.Carga2Id = new SelectList(db.Cargas, "Id", "Apelido", procTubo.Carga2Id);
            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla", procTubo.EmbalagemId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", procTubo.ProdutoId);
            ViewBag.ResinaBaseId = new SelectList(db.ResinasBase, "Id", "Apelido", procTubo.ResinaBaseId);
            ViewBag.SerieId = new SelectList(db.Series, "Id", "Apelido", procTubo.SerieId);
            return View(procTubo);
        }

        // GET: ProcTuboes/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var procTubo = db.ProcTubos
                .Include(p => p.Carga1)
                .Include(p => p.Carga2)
                .Include(p => p.Embalagem)
                .Include(p => p.Produto)
                .Include(p => p.ResinaBase)
                .Include(p => p.Serie)
                .SingleOrDefault(p => p.Id == id);

            if (procTubo == null)
            {
                return HttpNotFound();
            }
            return View(procTubo);
        }

        // POST: ProcTuboes/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var procTubo = db.ProcTubos
                .Include(p => p.Carga1)
                .Include(p => p.Carga2)
                .Include(p => p.Embalagem)
                .Include(p => p.Produto)
                .Include(p => p.ResinaBase)
                .Include(p => p.Serie)
                .SingleOrDefault(p => p.Id == id);

            return View("Erase", procTubo);
        }

        // POST: ProcTuboes/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            var procTubo = db.ProcTubos
                .Include(p => p.Carga1)
                .Include(p => p.Carga2)
                .Include(p => p.Embalagem)
                .Include(p => p.Produto)
                .Include(p => p.ResinaBase)
                .Include(p => p.Serie)
                .SingleOrDefault(p => p.Id == id);
            db.ProcTubos.Remove(procTubo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var procTubo = db.ProcTubos
                .Include(p => p.Carga1)
                .Include(p => p.Carga2)
                .Include(p => p.Embalagem)
                .Include(p => p.Produto)
                .Include(p => p.ResinaBase)
                .Include(p => p.Serie)
                .SingleOrDefault(p => p.Cadastro == search);

            if (procTubo == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo proctubo {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", procTubo);
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
