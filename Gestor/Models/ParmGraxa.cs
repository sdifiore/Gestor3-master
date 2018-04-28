using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class ParmGraxa
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(64)]
        public string Descricao { get; set; }

        [Display(Name = "Minuto por carga")]
        public float? Pesagem { get; set; }

        [Display(Name = "Kg/h")]
        public float KgH { get; set; }

        [Display(Name = "Totaliza")]
        public bool Totaliza { get; set; }
    }
}