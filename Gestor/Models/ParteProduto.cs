using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class ParteProduto
    {
        public int ParteProdutoId { get; set; }

        [Display(Name = "Grupo de Rateio")]
        public int GrupoRateioId { get; set; }

        public GrupoRateio GrupoRateio { get; set; }

        [Display(Name = "Peso Líquido")]
        public float Peso { get; set; }

        [Display(Name = "Ativo")]
        public bool Status { get; set; }

        [Display(Name = "IPI")]
        public float Ipi { get; set; }

        [Display(Name = "Qtd / Unidade")]
        public int QtdUndd { get; set; }

        [Display(Name = "Domínio")]
        public int DominioId { get; set; }

        public Dominio Dominio { get; set; }

        [Display(Name = "Tipo de Produção")]
        public int TipoProducaoId { get; set; }

        public TipoProducao TipoProducao { get; set; }

        [Display(Name = "PCP")]
        public int PcpId { get; set; }

        public Pcp Pcp { get; set; }

        [Display(Name = "Qtd Und / Und Armazenamento")]
        public int QtdUndArmz { get; set; }

        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
    }
}