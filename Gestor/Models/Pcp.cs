using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Pcp
    {
        public int PcpId { get; set; }

        [StringLength(2)]
        [Display(Name = "PCP")]
        public string Descricao { get; set; }
    }
}