using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Familia
    {
        public int FamiliaId { get; set; }

        [StringLength(3)]
        [Display(Name = "Família")]
        public string Apelido { get; set; }

        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}