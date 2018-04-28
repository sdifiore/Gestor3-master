using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Models
{
    [Table("QuadrosPercentuais")]
    public class QuadroPercentual
    {
        public int Id { get; set; }

        [Display(Name = "Receita Liquida Global Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlGlobalFita { get; set; }

        [Display(Name = "Receita Liquida Global Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlGlobalTubo { get; set; }

        [Display(Name = "Receita Liquida Global Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlGlobalFiotec { get; set; }

        [Display(Name = "Receita Liquida Global Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlGlobalGxpuro { get; set; }

        [Display(Name = "Receita Liquida Global Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlGlobalGxgraf { get; set; }

        [Display(Name = "Receita Liquida Global Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlGlobalGraxa { get; set; }

        [Display(Name = "Receita Liquida Global Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlGlobalRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Receita Liquida Próprias Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlPropriaFita { get; set; }

        [Display(Name = "Receita Liquida Próprias Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlPropriaTubo { get; set; }

        [Display(Name = "Receita Liquida Próprias Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlPropriaFiotec { get; set; }

        [Display(Name = "Receita Liquida Próprias Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlPropriaGxpuro { get; set; }

        [Display(Name = "Receita Liquida Próprias Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlPropriaGxgraf { get; set; }

        [Display(Name = "Receita Liquida Próprias Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlPropriaGraxa { get; set; }

        [Display(Name = "Receita Liquida Próprias Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlPropriaRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Receita Liquida Terceiros Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlTerceirosFita { get; set; }

        [Display(Name = "Receita Liquida Terceiros Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlTerceirosTubo { get; set; }

        [Display(Name = "Receita Liquida Terceiros Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlTerceirosFiotec { get; set; }

        [Display(Name = "Receita Liquida Terceiros Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlTerceirosGxpuro { get; set; }

        [Display(Name = "Receita Liquida Terceiros Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlTerceirosGxgraf { get; set; }

        [Display(Name = "Receita Liquida Terceiros Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlTerceirosGraxa { get; set; }

        [Display(Name = "Receita Liquida Terceiros Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float RlTerceirosRevenda { get; set; }

        //------------------------------------------------
        //------------------------------------------------

        [Display(Name = "Peso Líquido Global Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlGlobalFita { get; set; }

        [Display(Name = "Receita Liquida Global Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlGlobalTubo { get; set; }

        [Display(Name = "Peso Liquido Global Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlGlobalFiotec { get; set; }

        [Display(Name = "Peso Liquido Global Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlGlobalGxpuro { get; set; }

        [Display(Name = "Peso Liquido Global Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlGlobalGxgraf { get; set; }

        [Display(Name = "Peso Liquido Global Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlGlobalGraxa { get; set; }

        [Display(Name = "Peso Liquido Global Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlGlobalRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Peso Liquido Próprias Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlPropriaFita { get; set; }

        [Display(Name = "Peso Liquido Próprias Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlPropriaTubo { get; set; }

        [Display(Name = "Peso Liquido Próprias Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlPropriaFiotec { get; set; }

        [Display(Name = "Peso Liquido Próprias Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlPropriaGxpuro { get; set; }

        [Display(Name = "Peso Liquido Próprias Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlPropriaGxgraf { get; set; }

        [Display(Name = "Peso Liquido Próprias Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlPropriaGraxa { get; set; }

        [Display(Name = "Peso Liquido Próprias Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlPropriaRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Peso Liquido Terceiros Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlTerceirosFita { get; set; }

        [Display(Name = "Peso Liquido Terceiros Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlTerceirosTubo { get; set; }

        [Display(Name = "Peso Liquido Terceiros Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlTerceirosFiotec { get; set; }

        [Display(Name = "Peso Liquido Terceiros Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlTerceirosGxpuro { get; set; }

        [Display(Name = "Peso Liquido Terceiros Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlTerceirosGxgraf { get; set; }

        [Display(Name = "Peso Liquido Terceiros Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlTerceirosGraxa { get; set; }

        [Display(Name = "Peso Liquido Terceiros Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PlTerceirosRevenda { get; set; }

        //------------------------------------------------
        //------------------------------------------------

        [Display(Name = "Horas MOD Global Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmGlobalFita { get; set; }

        [Display(Name = "Receita Liquida Global Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmGlobalTubo { get; set; }

        [Display(Name = "Horas MOD Global Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmGlobalFiotec { get; set; }

        [Display(Name = "Horas MOD Global Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmGlobalGxpuro { get; set; }

        [Display(Name = "Horas MOD Global Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmGlobalGxgraf { get; set; }

        [Display(Name = "Horas MOD Global Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmGlobalGraxa { get; set; }

        [Display(Name = "Horas MOD Global Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmGlobalRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Horas MOD Próprias Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmPropriaFita { get; set; }

        [Display(Name = "Horas MOD Próprias Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmPropriaTubo { get; set; }

        [Display(Name = "Horas MOD Próprias Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmPropriaFiotec { get; set; }

        [Display(Name = "Horas MOD Próprias Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmPropriaGxpuro { get; set; }

        [Display(Name = "Horas MOD Próprias Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmPropriaGxgraf { get; set; }

        [Display(Name = "Horas MOD Próprias Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmPropriaGraxa { get; set; }

        [Display(Name = "Horas MOD Próprias Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmPropriaRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Horas MOD Terceiros Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmTerceirosFita { get; set; }

        [Display(Name = "Horas MOD Terceiros Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmTerceirosTubo { get; set; }

        [Display(Name = "Horas MOD Terceiros Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmTerceirosFiotec { get; set; }

        [Display(Name = "Horas MOD Terceiros Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmTerceirosGxpuro { get; set; }

        [Display(Name = "Horas MOD Terceiros Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmTerceirosGxgraf { get; set; }

        [Display(Name = "Horas MOD Terceiros Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmTerceirosGraxa { get; set; }

        [Display(Name = "Horas MOD Terceiros Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float HmTerceirosRevenda { get; set; }

        //------------------------------------------------
        //------------------------------------------------

        [Display(Name = "Qt Individ ProdutoGlobal Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipGloballFita { get; set; }

        [Display(Name = "Receita Liquida Global Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipGloballTubo { get; set; }

        [Display(Name = "Qt Individ ProdutoGlobal Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipGloballFiotec { get; set; }

        [Display(Name = "Qt Individ ProdutoGlobal Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipGloballGxpuro { get; set; }

        [Display(Name = "Qt Individ ProdutoGlobal Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipGloballGxgraf { get; set; }

        [Display(Name = "Qt Individ ProdutoGlobal Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipGloballGraxa { get; set; }

        [Display(Name = "Qt Individ ProdutoGlobal Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipGloballRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Qt Individ ProdutoPróprias Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipPropriaFita { get; set; }

        [Display(Name = "Qt Individ ProdutoPróprias Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipPropriaTubo { get; set; }

        [Display(Name = "Qt Individ ProdutoPróprias Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipPropriaFiotec { get; set; }

        [Display(Name = "Qt Individ ProdutoPróprias Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipPropriaGxpuro { get; set; }

        [Display(Name = "Qt Individ ProdutoPróprias Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipPropriaGxgraf { get; set; }

        [Display(Name = "Qt Individ ProdutoPróprias Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipPropriaGraxa { get; set; }

        [Display(Name = "Qt Individ ProdutoPróprias Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipPropriaRevenda { get; set; }

        //------------------------------------------------

        [Display(Name = "Qt Individ ProdutoTerceiros Fita")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipTerceirosFita { get; set; }

        [Display(Name = "Qt Individ ProdutoTerceiros Tubo")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipTerceirosTubo { get; set; }

        [Display(Name = "Qt Individ ProdutoTerceiros Fiotec")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipTerceirosFiotec { get; set; }

        [Display(Name = "Qt Individ ProdutoTerceiros Gxpuro")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipTerceirosGxpuro { get; set; }

        [Display(Name = "Qt Individ ProdutoTerceiros Gxgraf")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipTerceirosGxgraf { get; set; }

        [Display(Name = "Qt Individ ProdutoTerceiros Graxa")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipTerceirosGraxa { get; set; }

        [Display(Name = "Qt Individ ProdutoTerceiros Revenda")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float QipTerceirosRevenda { get; set; }
    }
}