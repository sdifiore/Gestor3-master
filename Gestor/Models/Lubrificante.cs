using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Lubrificante
    {
        public int Id { get; set; }

        [StringLength(1)]
        [Display(Name = "ref")]
        public string Ref { get; set; }

        [StringLength(16)]
        [Display(Name = "Referência")]
        public string Referencia { get; set; }

        public int InsumoId { get; set; }

        public Insumo Insumo { get; set; }
    }
}