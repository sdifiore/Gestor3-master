using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Resina
    {
        public int Id { get; set; }

        [Display(Name = "Resina")]
        [StringLength(16)]
        public string Descricao { get; set; }
    }
}