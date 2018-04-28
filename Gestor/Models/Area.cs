using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Area
    {
        public int AreaId { get; set; }

        [StringLength(2)]
        [Display(Name = "Código")]
        public string Apelido { get; set; }

        [StringLength(16)]
        [Display(Name = "Área")]
        public string Nome { get; set; }
    }
}