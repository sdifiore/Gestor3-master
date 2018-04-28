using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Unidade
    {
        public int UnidadeId { get; set; }

        [StringLength(2)]
        [Display(Name = "Unidade")]
        public string Apelido { get; set; }

        [StringLength(16)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}