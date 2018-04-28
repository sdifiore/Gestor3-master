using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class GrupoRateio
    {
        public int GrupoRateioId { get; set; }

        [StringLength(6)]
        [Display(Name = "Código")]
        public string Apelido { get; set; }

        [StringLength(128)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public float Fita { get; set; }

        public float Tubo { get; set; }

        public float Fiotec { get; set; }

        public float Gxpuro { get; set; }

        public float Gxgraf { get; set; }

        public float Graxa { get; set; }

        public float Revenda { get; set; }

        public float Total { get; set; }

    }
}