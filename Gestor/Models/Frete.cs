using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Frete
    {
        public int FreteId { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "Frete CIF médio na Grande São Paulo")]
        public float CifGrandeSp { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "Frete CIF médio fora da Grande São Paulo")]
        public float CifForaGrandeSp { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "Frete Médio Regiões de ICMS 18%")]
        public float RegioesIcms18 { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "Frete Médio Regiões de ICMS 12%")]
        public float RegioesIcms12 { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "Frete Médio Regiões de ICMS 7%")]
        public float RegioesIcms7 { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}