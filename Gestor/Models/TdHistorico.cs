using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Models
{
    [Table("TdHistoricos")]
    public class TdHistorico
    {
        public int Id { get; set; }

        [StringLength(16)]
        public string Totalizador { get; set; }

        [Display(Name = "Própria Rec Liq")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float PropRecLiq { get; set; }

        [Display(Name = "Própria Peso")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float PropPeso { get; set; }

        [Display(Name = "Própria Horas")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float PropHoras { get; set; }

        [Display(Name = "Própria Quant")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float PropQuant { get; set; }

        [Display(Name = "Terceiros Rec Liq")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float TercRecLiq { get; set; }

        [Display(Name = "Terceiros Peso")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float TercPeso { get; set; }

        [Display(Name = "Terceiros Horas")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float TercHoras { get; set; }

        [Display(Name = "Terceiros Quant")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float TercQuant { get; set; }
    }
}