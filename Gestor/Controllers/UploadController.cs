using Gestor.Models;
using System;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Gestor.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ViewResult UploadFile()
        {
            ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoCargos;
            ViewBag.retorno = "UploadFile";
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), file.FileName);
                    file.SaveAs(path);
                    Populate.CustosCargos(path);
                    System.IO.File.Delete(path);
                    var memoria = db.Memorias.First();
                    memoria.AtualizacaoCargos = DateTime.Now;
                    db.SaveChanges();
                }

                ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoCargos;
                ViewBag.Message = Global.AtualizacaoOk;
                return View();
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, $"Upload.UploadFile: {ex.Message}");
                ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoCargos;
                ViewBag.Message = "Ocorreu um erro. Tente novamente ou consulte a log do sistema.";
                ViewBag.retorno = "UploadFile";
                return View();
            }
        }

        [HttpGet]
        public ViewResult DespFixas()
        {
            ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoDespFixas;
            ViewBag.retorno = "DespFixas";
            return View("UploadFile");
        }

        [HttpPost]
        public ViewResult DespFixas(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), file.FileName);
                    file.SaveAs(path);
                    Populate.DespFixas(path);
                    System.IO.File.Delete(path);
                    var memoria = db.Memorias.First();
                    memoria.AtualizacaoDespFixas = DateTime.Now;
                    db.SaveChanges();
                }

                ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoDespFixas;
                ViewBag.Message = Global.AtualizacaoOk;
                ViewBag.retorno = "DespFixas";
                return View("UploadFile");
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, $"Upload.DespFixas: {ex.Message}");
                ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoDespFixas;
                ViewBag.Message = "Ocorreu um erro. Tente novamente ou consulte a log do sistema.";
                ViewBag.retorno = "DespFixas";
                return View("UploadFile");
            }
        }

        [HttpGet]
        public ViewResult FatHist()
        {
            ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoFatHistorico;
            ViewBag.retorno = "FatHist";
            return View("UploadFile");
        }

        [HttpPost]
        public ActionResult FatHist(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), file.FileName);
                    file.SaveAs(path);
                    Populate.FatHist(path);
                    System.IO.File.Delete(path);
                    var memoria = db.Memorias.First();
                    memoria.AtualizacaoFatHistorico = DateTime.Now;
                    db.SaveChanges();
                }

                ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoFatHistorico;
                ViewBag.Message = Global.AtualizacaoOk;
                ViewBag.retorno = "FatHist";
                return View("UploadFile");
            }
            catch (Exception ex)
            {
                DbLogger.Log(Reason.Error, $"Upload.FatHist: {ex.Message}");
                ViewBag.UltimaAtualizacao = db.Memorias.First().AtualizacaoFatHistorico;
                ViewBag.Message = "Ocorreu um erro. Tente novamente ou consulte a log do sistema.";
                ViewBag.retorno = "FatHist";
                return View("UploadFile");
    }
}
    }
}