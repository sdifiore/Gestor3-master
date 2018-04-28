using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Process
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string CodigoOperacao { get; set; }

        [StringLength(3)]
        public string Setor { get; set; }

        public string Descricao { get; set; }

        public float TaxaOcupacao { get; set; }

        public string Comentario { get; set; }

        public int QuantidadeMaquinas { get; set; }

        public float CustoHora { get; set; }
    }
}