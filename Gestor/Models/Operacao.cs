using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Operacao
    {
        public int OperacaoId { get; set; }

        [StringLength(10)]
        [Display(Name = "Código")]
        public string CodigoOperacao { get; set; }

        [StringLength(100)]
        [Display(Name = "Setor de Produção")]
        public string SetorProducao { get; set; }

        [StringLength(100)]
        [Display(Name = "Descrição da Operação")]
        public string Descricao { get; set; }

        [Display(Name = "Taxa de Ocupação")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float TaxaOcupacao { get; set; }

        [Display(Name = "Ineficiência Adotada")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float IneficienciaAdotada { get; set; }

        [StringLength(128)]
        [Display(Name = "Comentário")]
        public string Comentario { get; set; }

        [Display(Name = "Quantidade de Máquinas")]
        public int QtdMaquinas { get; set; }

        [Display(Name = "Custo em R$/h")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Custo { get; set; }

        [Display(Name = "Setor")]
        public int SetorId { get; set; }

        public Setor Setor { get; set; }
    }
}