using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [StringLength(2)]
        [Display(Name = "Categoria")]
        public string Apelido { get; set; }

        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}