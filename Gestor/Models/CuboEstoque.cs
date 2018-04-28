using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class CuboEstoque
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [StringLength(10)]
        public string Apelido { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(256)]
        public string Descricao { get; set; }

        [Display(Name = "Classe de Custo")]
        [StringLength(32)]
        public string ClasseCusto { get; set; }

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float Quantidade { get; set; }
    }
}