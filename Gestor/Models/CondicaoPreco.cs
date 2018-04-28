using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class CondicaoPreco
    {
        public int Id { get; set; }

        [StringLength(3)]
        [Display(Name = "Sigla")]
        public string Apelido { get; set; }

        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}