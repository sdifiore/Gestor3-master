using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Models
{
    [Table("LogData")]
    public class LogData
    {
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [MaxLength(5)]
        public string Reason { get; set; }

        [Required]
        [MaxLength(256)]
        public string Message { get; set; }
    }
}