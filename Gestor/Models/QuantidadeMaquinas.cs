using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class QtdMaquinas
    {
        public int Id { get; set; }

        [StringLength(8)]
        [Display(Name = "Máquina ou Linha")]
        public string Linha { get; set; }

        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade de Máquinas")]
        public int QuantidadeMaquinas { get; set; }
    }
}