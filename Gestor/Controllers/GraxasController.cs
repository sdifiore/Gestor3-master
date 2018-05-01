using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class GraxasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Graxas
        public ActionResult Index(int? page)
        {
            var graxas = db.Graxas
                .Include(g => g.Embalagem)
                .Include(g => g.Resina)
                .OrderBy(g => g.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = graxas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Graxas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Graxa graxa = db.Graxas
                .Include(g => g.Embalagem)
                .Include(g => g.Resina)
                .SingleOrDefault(g => g.Id == id);

            if (graxa == null)
            {
                return HttpNotFound();
            }
            return View(graxa);
        }

        // GET: Graxas/Create
        public ActionResult Create()
        {
            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla");
            ViewBag.ResinaId = new SelectList(db.Resinas, "Id", "Descricao");
            return View();
        }

        // POST: Graxas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apelido,Descricao,EmbalagemId,Peso,PctSilicone,PctSilica,PctPtfe,ResinaId,PesagemMinUn,Mistura,EmbalagemMedida,Rotulagem,LoteMinino,Ptfe,Silicone,Silica,PesagemH,MisturaH,EmbalarH,RotularH")] Graxa graxa)
        {
            if (ModelState.IsValid)
            {
                db.Graxas.Add(graxa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla", graxa.EmbalagemId);
            ViewBag.ResinaId = new SelectList(db.Resinas, "Id", "Descricao", graxa.ResinaId);
            return View(graxa);
        }

        // GET: Graxas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graxa graxa = db.Graxas.Find(id);
            if (graxa == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla", graxa.EmbalagemId);
            ViewBag.ResinaId = new SelectList(db.Resinas, "Id", "Descricao", graxa.ResinaId);
            return View(graxa);
        }

        // POST: Graxas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apelido,Descricao,EmbalagemId,Peso,PctSilicone,PctSilica,PctPtfe,ResinaId,PesagemMinUn,Mistura,EmbalagemMedida,Rotulagem,LoteMinino,Ptfe,Silicone,Silica,PesagemH,MisturaH,EmbalarH,RotularH")] Graxa graxa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graxa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmbalagemId = new SelectList(db.Embals, "Id", "Sigla", graxa.EmbalagemId);
            ViewBag.ResinaId = new SelectList(db.Resinas, "Id", "Descricao", graxa.ResinaId);
            return View(graxa);
        }

        // GET: Graxas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Graxa graxa = db.Graxas
                .Include(g => g.Embalagem)
                .Include(g => g.Resina)
                .SingleOrDefault(g => g.Id == id);

            if (graxa == null)
            {
                return HttpNotFound();
            }

            return View(graxa);
        }

        // POST: Graxas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graxa graxa = db.Graxas
                .Include(g => g.Embalagem)
                .Include(g => g.Resina)
                .SingleOrDefault(g => g.Id == id);

            return View("Erase", graxa);
        }

        // POST: Graxas/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Graxa graxa = db.Graxas.Find(id);
            db.Graxas.Remove(graxa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var graxa = db.Graxas
                .Include(g => g.Embalagem)
                .Include(g => g.Resina)
                .SingleOrDefault(g => g.Apelido == search);

            if (graxa == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo insumo {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }

            return View("Details", graxa);
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
