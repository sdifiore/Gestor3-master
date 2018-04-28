using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Estado
    {
        public int Id { get; set; }

        public int CodigoUf { get; set; }

        [MaxLength(20)]
        [Display(Name = "Estado")]
        public string Descricao { get; set; }

        [MaxLength(2)]
        [Display(Name = "UF")]
        public string Uf { get; set; }

        public int RegiaId { get; set; }

        [Display(Name = "Região")]
        public Regiao Regiao { get; set; }
    }
}