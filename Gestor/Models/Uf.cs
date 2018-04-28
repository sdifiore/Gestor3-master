using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestor.Models
{
    public class Uf
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }

        [StringLength(32)]
        public string Nome { get; set; }
    }
}