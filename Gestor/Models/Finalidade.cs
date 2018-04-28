using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Finalidade
    {
        public int FinalidadeId { get; set; }

        [Display(Name = "Finalidade")]
        [StringLength(32)]
        public string Descricao { get; set; }
    }
}