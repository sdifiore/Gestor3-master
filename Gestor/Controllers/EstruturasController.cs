using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Data;
using System.Web.Mvc;
using Gestor.Models;
using X.PagedList;

namespace Gestor.Controllers
{
    public class EstruturasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estruturas
        public ActionResult Index(int? page)
        {
            var estruturas = db.Estruturas
                .Include(e => e.Produto)
                .Include(e => e.Sequencia)
                .Include(e => e.Unidade)
                .Include(e => e.UnidadeCompra)
                .Include(e => e.Familia)
                .Include(e => e.Linha)
                .Include(e => e.Categoria)
                .OrderBy(e => e.Produto.Apelido);

            var pageNumber = page ?? 1;
            var onePageHistory = estruturas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
        }

        // GET: Estruturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var estrutura = db.Estruturas
                .Include(e => e.Produto)
                .Include(e => e.Sequencia)
                .Include(e => e.Unidade)
                .Include(e => e.UnidadeCompra)
                .Include(e => e.Familia)
                .Include(e => e.Linha)
                .Include(e => e.Categoria)
                .SingleOrDefault(e => e.Id == id);

            if (estrutura == null)
            {
                return HttpNotFound();
            }
            return View(estrutura);
        }

        public ActionResult Edit(int? id)
        {
            var produtoId = db.Estruturas.Find(id).ProdutoId;
            Session["struDestino"] = produtoId;
            Session["ViewBagTitle"] = "Alterar estrutura";

            return RedirectToAction("EditAlterStu");
        }

        public ViewResult CreateStru()
        {
            var estrutura = new Estrutura();
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");

            return View(estrutura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStru(int produtoId)
        {
            Session["struDestino"] = produtoId;
            Session["ViewBagTitle"] = "Criar estrutura";

            return RedirectToAction("CreateItem");
        }

        public ActionResult CopyStru(string id)
        {
            int estruturaId = int.Parse(id);
            var estrutura = db.Estruturas.First(e => e.Id == estruturaId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Apelido");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Descricao");
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao");
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Descricao");
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Descricao");
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo");
            Session["StruOrigem"] = estrutura.ProdutoId;

            return View(estrutura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CopyStru(int ProdutoId)
        {
            Session["struDestino"] = ProdutoId;
            Session["ViewBagTitle"] = "Copiar estrutura";

            return RedirectToAction("AlterStru");
        }

        public ActionResult AlterStru()
        {
            int produtoId = (int)Session["struDestino"];
            int struOriId = (int)Session["StruOrigem"];
            ViewBag.Title = Session["ViewBagTitle"];
            var estruturas = Clone(produtoId, struOriId);

            return RedirectToAction("EditAlterStu");
        }

        public ActionResult EditAlterStu()
        {
            var struDestino = (int)Session["struDestino"];
            var estrutura = db.Estruturas.Where(e => e.ProdutoId == struDestino);

            if (estrutura.Any()) return View(estrutura);

            return RedirectToAction("Index");
        }

        public ViewResult CreateItem()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao");
            ViewBag.FamiliaId = new SelectList(db.Familias, "FamiliaId", "Descricao");
            ViewBag.LinhaId = new SelectList(db.Linhas, "LinhaId", "Descricao");
            ViewBag.SequenciaId = new SelectList(db.Sequencias, "SequenciaId", "Tipo");
            ViewBag.UnidadeId = new SelectList(db.Unidades, "UnidadeId", "Descricao");
            ViewBag.Item = ListAddOptions();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "UnidadeId,QtdCusto,SequenciaId,Item,Onera,Lote,Perda,Observacao,CategoriaId,FamiliaId,LinhaId")] Estrutura estrutura)
        {
            estrutura.ProdutoId = (int)Session["struDestino"];
            estrutura.DescCompProc = GetDescricao(estrutura.Item);
            db.Estruturas.Add(estrutura);
            db.SaveChanges();

            return RedirectToAction("EditAlterStu");
        }

        public ActionResult DeleteItem(int id)
        {
            var estrutura = db.Estruturas
                .Include(e => e.Produto)
                .Include(e => e.Sequencia)
                .Include(e => e.Unidade)
                .Include(e => e.UnidadeCompra)
                .Include(e => e.Familia)
                .Include(e => e.Linha)
                .Include(e => e.Categoria)
                .SingleOrDefault(e => e.Id == id);

            if (estrutura == null)
            {
                return HttpNotFound();
            }

            return View(estrutura);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            var toBeDeleted = db.Estruturas.Find(id);
            db.Estruturas.Remove(toBeDeleted);
            db.SaveChanges();

            return RedirectToAction("EditAlterStu");
        }

        private IQueryable<Estrutura> Clone(int produtoId, int struOriId)
        {
            var estruturas = db.Estruturas.Where(e => e.ProdutoId == struOriId);
            

            foreach (var estrutura in estruturas)
            {
                db.Entry(estrutura).State = EntityState.Detached;
                estrutura.Id = 0;
                estrutura.ProdutoId = produtoId;
                db.Entry(estrutura).State = EntityState.Added;
            }
            
            db.SaveChanges();

            return estruturas;
        }

        private SelectList ListAddOptions()
        {
            var produtos = db.Produtos.Select(p => p.Apelido);
            var insumos = db.Insumos.Select(p => p.Apelido);
            var operacoes = db.Operacoes.Select(o => o.CodigoOperacao);
            var listaIni = produtos.Concat(insumos);
            var lista = listaIni.Concat(operacoes);

            return new SelectList(lista);
        }
        
        private string GetDescricao(string codigo)
        {
            string result = "";

            var insumo = db.Insumos.SingleOrDefault(i => i.Apelido == codigo);

            if (insumo == null)
            {
                var produto = db.Produtos.SingleOrDefault(p => p.Apelido == codigo);

                if (produto == null)
                {
                    var operacao = db.Operacoes.SingleOrDefault(o => o.CodigoOperacao == codigo);

                    if (operacao != null) result = operacao.Descricao;
                }

                else result = produto.Descricao;
            }

            else result = insumo.Descricao;

            return result;
        }

        // GET: Estruturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var estrutura = db.Estruturas
                .Include(e => e.Produto)
                .Include(e => e.Sequencia)
                .Include(e => e.Unidade)
                .Include(e => e.UnidadeCompra)
                .Include(e => e.Familia)
                .Include(e => e.Linha)
                .Include(e => e.Categoria)
                .SingleOrDefault(e => e.Id == id);

            if (estrutura == null)
            {
                return HttpNotFound();
            }

            return View(estrutura);
        }

        // POST: Estruturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estrutura estrutura = db.Estruturas.Find(id);

            return View("Erase", estrutura);
        }

        // POST: Estruturas/Erase/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Erase(int id)
        {
            Estrutura estrutura = db.Estruturas.Find(id);
            db.Estruturas.Remove(estrutura);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(int? page, string search)
        {
            var estruturas = db.Estruturas
                .Include(e => e.Produto)
                .Include(e => e.Sequencia)
                .Include(e => e.Unidade)
                .Include(e => e.UnidadeCompra)
                .Include(e => e.Familia)
                .Include(e => e.Linha)
                .Include(e => e.Categoria)
                .Where(e => e.Produto.Apelido == search);

            if (!estruturas.Any())
            {
                DbLogger.Log(Reason.Info, $"Procura pela estrutura {search} não produziu resultado");
                return Content($"Item {search} não encontrado");
            }
            var pageNumber = page ?? 1;
            var onePageHistory = estruturas.ToPagedList(pageNumber, Global.PageNumber);

            ViewBag.OnePageHistory = onePageHistory;

            return View();
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
