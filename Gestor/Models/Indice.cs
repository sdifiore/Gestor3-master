using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Indice
    {
        public int Id { get; set; }

        [StringLength(128)]
        [Display(Name = "Índice")]
        public string Descricao { get; set; }

        [Display(Name = "Próprio")]
        public float Proprio { get; set; }

        [Display(Name = "Terceiros")]
        public float Terceiros { get; set; }

        [Display(Name = "Exportação")]
        public float Exportacao { get; set; }
    }
}