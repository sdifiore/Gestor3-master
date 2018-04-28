using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Dominio
    {
        public int DominioId { get; set; }

        [StringLength(16)]
        [Display(Name = "Domínio da Produção")]
        public string Descricao { get; set; }
    }
}