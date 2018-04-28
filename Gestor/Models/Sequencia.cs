using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Sequencia
    {
        public int SequenciaId { get; set; }

        [StringLength(2)]
        [Display(Name = "Sequência")]
        public string Tipo { get; set; }

        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}