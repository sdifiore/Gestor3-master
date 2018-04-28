using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class PrecoNacional
    {
        public int Id { get; set; }

        [StringLength(128)]
        [Display(Name = "Linha / Un")]
        public string LinhaUn { get; set; }

        [StringLength(128)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [StringLength(10)]
        [Display(Name = "Código")]
        public string Apelido { get; set; }

        [Display(Name = "IPI")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float Ipi { get; set; }

        [Display(Name = "Qt/Unid")]
        public int QtUnid { get; set; }

        [Display(Name = "Tipo Produção")]
        public int TipoProducaoId { get; set; }

        public virtual TipoProducao TipoProducao { get; set; }

        [Display (Name = "Nível 1")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I18Nivel1 { get; set; }

        [Display(Name = "Nível 2")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I18Nivel2 { get; set; }

        [Display(Name = "Nível 3")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I18Nivel3 { get; set; }

        [Display(Name = "Nível 1")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I12Nivel1 { get; set; }

        [Display(Name = "Nível 2")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I12Nivel2 { get; set; }

        [Display(Name = "Nível 3")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I12Nivel3 { get; set; }

        [Display(Name = "Nível 1")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I7Nivel1 { get; set; }

        [Display(Name = "Nível 2")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I7Nivel2 { get; set; }

        [Display(Name = "Nível 3")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float I7Nivel3 { get; set; }

        public float Com { get; set; }

        [Display(Name = "LL min")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float LlMin { get; set; }

        [Display(Name = "Preço Refer")]
        public float PrecoRefer { get; set; }

        [Display(Name = "Aplic do Roteiro")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public float AplicRoteiro { get; set; }

        [Display(Name = "Custo Direto")]
        public float CustoDireto { get; set; }

        [Display(Name = "Rateio Custos Fixos")]
        public float RateioCustoFixo { get; set; }

        public float Aumento { get; set; }
    }
}