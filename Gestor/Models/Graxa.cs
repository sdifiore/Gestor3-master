using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Graxa
    {
        public int Id { get; set; }

        [StringLength(10)]
        [Display(Name = "Código")]
        public string Apelido { get; set; }

        [StringLength(100)]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Embalagem")]
        public int EmbalagemId { get; set; }

        public virtual Embal Embalagem { get; set; }

        [Display(Name = "Peso unitário")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Peso { get; set; }

        [Display(Name = "% Silicone")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PctSilicone { get; set; }

        [Display(Name = "% Sílica")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PctSilica { get; set; }

        [Display(Name = "% PTFE")]
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public float PctPtfe { get; set; }

        [Display(Name = "Resina")]
        public int ResinaId { get; set; }

        public virtual Resina Resina { get; set; }

        [Display(Name = "Pesagem min/un")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float PesagemMinUn { get; set; }

        [Display(Name = "Mistura min/un")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float Mistura { get; set; }

        [Display(Name = "Embalagem min/un")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float EmbalagemMedida { get; set; }

        [Display(Name = "Rotulagem min/un")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float Rotulagem { get; set; }

        [Display(Name = "Lote mínimo un")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float LoteMinino { get; set; }

        [Display(Name = "PTFE Kg")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float Ptfe { get; set; }

        [Display(Name = "Silicone Kg")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float Silicone { get; set; }

        [Display(Name = "Sílica Kg")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float Silica { get; set; }

        [Display(Name = "Pesagem h")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float PesagemH { get; set; }

        [Display(Name = "Mistura h")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float MisturaH { get; set; }

        [Display(Name = "Embalar h")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float EmbalarH { get; set; }

        [Display(Name = "Rotular h")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float RotularH { get; set; }
    }
}