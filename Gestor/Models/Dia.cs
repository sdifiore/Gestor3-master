using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Dia
    {
        [DataType(DataType.Date)]
        public DateTime Hoje { get; set; }
    }
}