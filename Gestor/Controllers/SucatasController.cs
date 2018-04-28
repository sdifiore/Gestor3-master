using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class SucatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sucatas
        public ActionResult Index(int? page)
        {
            var sucatas = db.Sucatas
                .Include(s => s.Produto)
                .OrderBy(s => s.Produto.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = sucatas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Sucatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucata sucata = db.Sucatas.Include(s => s.Produto).SingleOrDefault(s => s.SucataId == id);
            if (sucata == null)
            {
                return HttpNotFound();
            }
            return View(sucata);
        }

        // GET: Sucatas/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            return View();
        }

        // POST: Sucatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SucataId,Data,Cartucho,Carretel,CRefile,Jumbo216,SubProduto,ProdutoId")] Sucata sucata)
        {
            if (ModelState.IsValid)
            {
                sucata.Cartucho = sucata.Cartucho / 100;
                sucata.Carretel = sucata.Carretel / 100;
                sucata.CRefile = sucata.CRefile / 100;
                sucata.Jumbo216 = sucata.Jumbo216 / 100;

                db.Sucatas.Add(sucata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", sucata.ProdutoId);
            return View(sucata);
        }

        // GET: Sucatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucata sucata = db.Sucatas.Find(id);
            if (sucata == null)
            {
                return HttpNotFound();
            }
            sucata.Cartucho = sucata.Cartucho * 100;
            sucata.Carretel = sucata.Carretel * 100;
            sucata.CRefile = sucata.CRefile * 100;
            sucata.Jumbo216 = sucata.Jumbo216 * 100;

            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", sucata.ProdutoId);
            return View(sucata);
        }

        // POST: Sucatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SucataId,Data,Cartucho,Carretel,CRefile,Jumbo216,SubProduto,ProdutoId")] Sucata sucata)
        {
            if (ModelState.IsValid)
            {
                sucata.Cartucho = sucata.Cartucho / 100;
                sucata.Carretel = sucata.Carretel / 100;
                sucata.CRefile = sucata.CRefile / 100;
                sucata.Jumbo216 = sucata.Jumbo216 / 100;

                db.Entry(sucata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido", sucata.ProdutoId);
            return View(sucata);
        }

        // GET: Sucatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucata sucata = db.Sucatas.Include(s => s.Produto).SingleOrDefault(s => s.SucataId == id);
            if (sucata == null)
            {
                return HttpNotFound();
            }
            return View(sucata);
        }

        // POST: Sucatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucata sucata = db.Sucatas.Find(id);
            db.Sucatas.Remove(sucata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = db.Sucatas
                .Include(s => s.Produto)
                .FirstOrDefault(g => g.Produto.Apelido.Contains(search));

            if (model == null)
            {
                DbLogger.Log(Reason.Info, $"Procura pelo Sucata {search} não produziu resultado");
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
