using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Extrusora
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [StringLength(8)]
        public string Apelido { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}