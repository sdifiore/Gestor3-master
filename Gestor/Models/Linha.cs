using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Linha
    {
        public int LinhaId { get; set; }

        [StringLength(4)]
        [Display(Name = "Linha")]
        public string Apelido { get; set; }

        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}