using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Regiao
    {
        public int RegiaoId { get; set; }

        [MaxLength(3)]
        [Display(Name = "Código")]
        public string Apelido { get; set; }

        [MaxLength(12)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}