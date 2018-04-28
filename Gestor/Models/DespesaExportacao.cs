using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class DespesaExportacao
    {
        public int Id { get; set; }

        [StringLength(3)]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float Valor { get; set; }

        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}