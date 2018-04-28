using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class IndiceRateioFormacaoPrecoVenda
    {
        public int Id { get; set; }

        [Display(Name = "Grupo de Rateio")]
        public int GrupoRateioId { get; set; }

        public Rateio GrupoRateio { get; set; }     // Alterado de Grupo de Rateio para Rateio, manteve-se o nome GrupoRateio para preservar compatibilidade

        [Display(Name = "Total Custos Fixos")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float TotalCustoFixo { get; set; }

        [Display(Name = "MOI de Fabricação")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float MoiFabricacao { get; set; }

        [Display(Name = "Outros Custos Fixos Fabricação")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float OutroCustoFixoFabricacao { get; set; }

        [Display(Name = "Custo Fixo COMACS")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float CustoFixoComacs { get; set; }

        [Display(Name = "Custo Fixo COMTEX")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float CustoFixoComtex { get; set; }

        [Display(Name = "Custo Fixo Admin Log")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float CustoFixoAdminLog { get; set; }
    }
}