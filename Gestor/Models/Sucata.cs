using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Models
{
    public class Sucata
    {
        public int SucataId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float Cartucho { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float Carretel { get; set; }

        [Display(Name = "c/ Refile")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float CRefile { get; set; }

        [Display(Name = "Jumbo 216")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float Jumbo216 { get; set; }

        [Display(Name = "Sub-produto")]
        public bool SubProduto { get; set; }

        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }
}