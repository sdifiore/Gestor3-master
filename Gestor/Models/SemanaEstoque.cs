using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class SemanaEstoque
    {
        public int Id { get; set; }

        [StringLength(10)]
        [Display(Name = "Ítem")]
        public string Apelido { get; set; }

        [Display(Name = "Semanas")]
        public int Semanas { get; set; }
    }
}