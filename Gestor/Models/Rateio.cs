using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Rateio
    {
        public int RateioId { get; set; }

        [StringLength(20)]
        [Display(Name = "Grupo de Rateio dos Produtos")]
        public string Grupo { get; set; }

        [Display(Name = "Duração Mínima de OP's Horas")]
        public int Horas { get; set; }
    }
}