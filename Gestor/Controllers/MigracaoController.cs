using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestor.Models;

namespace Gestor.Controllers
{
    public class MigracaoController : Controller
    {
        // GET: Migracao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XlProduto()
        {
            DbLogger.Log(Reason.Info, "Início migração Produtos");

            ExcelProduto.Conta();

            DbLogger.Log(Reason.Info, "Migração Produtos encerrada");

            Console.WriteLine("Migração encerrada");

            Console.ReadLine();

            return RedirectToAction("Index", "Home");
        }
    }
}