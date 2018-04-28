using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class CustoInsumo
    {
        public int CustoInsumoId { get; set; }

        [Display(Name = "Preço Bruto de Compra")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float PrcBrtCmpr { get; set; }

        [Display(Name = "Crédito ICMS")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CrdtIcms { get; set; }

        [Display(Name = "Crédito IPI")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CrdtIpi { get; set; }

        [Display(Name = "Crédito PIS")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CrdtPis { get; set; }

        [Display(Name = "Crédito COFINS")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CrdtCofins { get; set; }

        [Display(Name = "Soma Crédito Impostos")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float SumCrdtImpostos { get; set; }

        [Display(Name = "Despesas de Importação")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float DespImport { get; set; }

        [Display(Name = "Custos Extras")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CustoExtra { get; set; }

        [Display(Name = "Custo")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Custo { get; set; }

        [Display(Name = "Custo Und Consumo")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CstUndConsumo { get; set; }

        [Display(Name = "Pgto Fornec. Import")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float PgmtoFornecImport { get; set; }

        [Display(Name = "Uso Estrutura")]
        public float UsoStrut { get; set; }

        [Display(Name = "Existe na rede?")]
        public bool ExisteRede { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
    }
}