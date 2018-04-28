using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Models
{
    public class ClasseCusto
    {
        public int ClasseCustoId { get; set; }

        [StringLength(2)]
        [Display(Name = "Classe de Custo")]
        public string Apelido { get; set; }

        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}