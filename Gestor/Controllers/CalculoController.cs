using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gestor.Controllers
{
    public class CalculoController : Controller
    {
        // GET: Calculo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Estrutura()
        {
            Populate.Estrutura();

            return Redirect("/");
        }

        public ActionResult Insumo()
        {
            Populate.Insumo();

            return Redirect("/");
        }

        public ActionResult Produto()
        {
            Populate.Produto();

            return Redirect("/");
        }

        public ActionResult EncapTubo()
        {
            Populate.EncapTubos();

            return Redirect("/");
        }

        public ActionResult Graxas()
        {
            Populate.Graxas();

            return Redirect("/");
        }

        public ActionResult PreForma()
        {
            Populate.PreForma();

            return Redirect("/");
        }

        public ActionResult ResinaPtfe()
        {
            Populate.ResinaPtfe();

            return Redirect("/");
        }

        public ActionResult ProcTubos()
        {
            Populate.ProcTubos();

            return Redirect("/");
        }

        public ActionResult PrecoNacional()
        {
            Populate.PrecoNacional();

            return Redirect("/");
        }

        public ActionResult PrecoExportacao()
        {
            Populate.PrecoExportacao();

            return Redirect("/");
        }

        public ActionResult DfxProdRev()
        {
            Populate.DfxProdRev();

            return Redirect("/");
        }

        public ActionResult PlanejMod()
        {
            Populate.PlanejMod();

            return Redirect("/");
        }

        public ActionResult PlanejCompra()
        {
            Populate.PlanejCompra();

            return Redirect("/");
        }

        public ActionResult PlanejNecessidade()
        {
            Populate.PlanejNecessidades();

            return Redirect("/");
        }

        public ActionResult PlanejVendas()
        {
            Populate.PlanejVendas();

            return Redirect("/");
        }

        public ActionResult PlanejProducao()
        {
            Populate.PlanejProducao();

            return Redirect("/");
        }

        public ActionResult Quadro()
        {
            Populate.Quadro();

            return Redirect("/");
        }

        public ActionResult QuadroPercentual()
        {
            Populate.QuadroPercentual();

            return Redirect("/");
        }

        public ActionResult GrupoRateio()
        {
            Populate.GrupoRateio();

            return Redirect("/");
        }

        public ActionResult FormacaoPrecoVenda()
        {
            Populate.FormacaoPrecoVenda();

            return Redirect("/");
        }

        public ActionResult Lucratividade()
        {
            Populate.Lucratividade();

            return Redirect("/");
        }


        public ActionResult Tudo()
        {
            for (int i = 0; i < 5; i++)
            {
                Populate.DfxProdRev();
                Populate.Quadro();
                Populate.QuadroPercentual();
                Populate.GrupoRateio();
                Populate.FormacaoPrecoVenda();
                Populate.Lucratividade();
                Populate.PrecoNacional();
                Populate.Insumo();
                Populate.Estrutura();
                Populate.Produto();
                Populate.PrecoExportacao();
                Populate.EncapTubos();
                Populate.Graxas();
                Populate.PreForma();
                Populate.ResinaPtfe();
                Populate.ProcTubos();
                Populate.PlanejVendas();
                Populate.PlanejMod();
                Populate.PlanejCompra();
                Populate.PlanejNecessidades();
                Populate.PlanejProducao(); 
            }

            return Redirect("/");
        }
    }
}