using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class PlanejModsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanejMods
        public ActionResult Index(int? page)
        {

            var planejMods = db.PlanejMods
                .Include(p => p.Operacao)
                .Include(p => p.Setor)
                .Include(p => p.Unidade)
                .OrderBy(p => p.Setor.Codigo);

            var pageNumber = page ?? 1;
            var onePageHistory = planejMods.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: PlanejMods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlanejMod planejMod = db.PlanejMods
                .Include(p => p.Operacao)
                .Include(p => p.Setor)
                .Include(p => p.Unidade)
                .SingleOrDefault(P => P.Id == id);

            if (planejMod == null)
            {
                return HttpNotFound();
            }
            return View(planejMod);
        }

        // GET: PlanejMods/Create
        public ActionResult Create()
        {
            ViewBag.OperacaoId = new SelectList(db.Operacoes, "OperacaoId", "CodigoOperacao");
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido");
            return View();
        }

        // POST: PlanejMods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OperacaoId,UnidadeId,SomaDe1,SomaDe2,SomaDe3,SomaDe4,SomaDe5,SomaDe6,SomaDe7,SomaDe8,SomaDe9,SomaDe10,SomaDe11,SomaDe12,AnoMenos11,AnoMenos10,AnoMenos9,AnoMenos8,AnoMenos7,AnoMenos6,AnoMenos5,AnoMenos4,AnoMenos3,AnoMenos2,AnoMenos1,Ano,SetorId,MediaMensal")] PlanejMod planejMod)
        {
            if (ModelState.IsValid)
            {
                db.PlanejMods.Add(planejMod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OperacaoId = new SelectList(db.Operacoes, "OperacaoId", "CodigoOperacao", planejMod.OperacaoId);
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", planejMod.SetorId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", planejMod.UnidadeId);
            return View(planejMod);
        }

        // GET: PlanejMods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanejMod planejMod = db.PlanejMods.Find(id);
            if (planejMod == null)
            {
                return HttpNotFound();
            }
            ViewBag.OperacaoId = new SelectList(db.Operacoes, "OperacaoId", "CodigoOperacao", planejMod.OperacaoId);
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", planejMod.SetorId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", planejMod.UnidadeId);
            return View(planejMod);
        }

        // POST: PlanejMods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OperacaoId,UnidadeId,SomaDe1,SomaDe2,SomaDe3,SomaDe4,SomaDe5,SomaDe6,SomaDe7,SomaDe8,SomaDe9,SomaDe10,SomaDe11,SomaDe12,AnoMenos11,AnoMenos10,AnoMenos9,AnoMenos8,AnoMenos7,AnoMenos6,AnoMenos5,AnoMenos4,AnoMenos3,AnoMenos2,AnoMenos1,Ano,SetorId,MediaMensal")] PlanejMod planejMod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planejMod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OperacaoId = new SelectList(db.Operacoes, "OperacaoId", "CodigoOperacao", planejMod.OperacaoId);
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Codigo", planejMod.SetorId);
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Apelido", planejMod.UnidadeId);
            return View(planejMod);
        }

        // GET: PlanejMods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlanejMod planejMod = db.PlanejMods
                .Include(p => p.Operacao)
                .Include(p => p.Setor)
                .Include(p => p.Unidade)
                .SingleOrDefault(P => P.Id == id);

            if (planejMod == null)
            {
                return HttpNotFound();
            }
            return View(planejMod);
        }

        // POST: PlanejMods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanejMod planejMod = db.PlanejMods
                .Include(p => p.Operacao)
                .Include(p => p.Setor)
                .Include(p => p.Unidade)
                .SingleOrDefault(P => P.Id == id);

            return View("Erase", planejMod);
        }

        // POST: PlanejMods/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            PlanejMod planejMod = db.PlanejMods.Find(id);
            db.PlanejMods.Remove(planejMod);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var planejMod = db.PlanejMods
                .Include(p => p.Operacao)
                .Include(p => p.Setor)
                .Include(p => p.Unidade)
                .SingleOrDefault(p => p.Operacao.CodigoOperacao == search);

            if (planejMod == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo insumo {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", planejMod);
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
