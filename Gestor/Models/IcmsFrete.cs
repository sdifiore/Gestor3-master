using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class IcmsFrete
    {
        public int Id { get; set; }

        [StringLength(16)]
        [Display(Name = "Rótulo")]
        public string Rotulo { get; set; }

        [Display(Name = "ICMS")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float Icms { get; set; }

        [Display(Name = "Frete")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float Frete { get; set; }
    }
}