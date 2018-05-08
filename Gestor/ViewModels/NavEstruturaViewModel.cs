using Gestor.Models;
using System.ComponentModel.DataAnnotations;

namespace Gestor.ViewModels
{
    public class NavEstruturaViewModel
    {
        public int ProdutoId { get; set; }

        [Display(Name = "Unidade Produto")]
        public int UnidadeId { get; set; }

        [Display(Name = "Quantidade para Custo")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float QtdCusto { get; set; }

        [Display(Name = "Sequência")]
        public int SequenciaId { get; set; }

        [StringLength(10)]
        [Display(Name = "Código Compra")]
        public string Item { get; set; }

        [Display(Name = "Onera")]
        public bool Onera { get; set; }

        [Display(Name = "Lote")]
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public float Lote { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "Perdas")]
        public float Perda { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [StringLength(16)]
        [Display(Name = "Ref Auxiliar Produto")]
        public string RefAuxiliarProduto { get; set; }

        public bool Forward { get; set; }

        public bool Backward { get; set; }
    }
}