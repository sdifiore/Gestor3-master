using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class PreForma
    {
        public int Id { get; set; }

        [Display(Name = "Pré Forma n°")]
        public int PreFormaNum { get; set; }

        [Display(Name = "Forma - ØE mm")]
        public int FormaDiamE { get; set; }

        [Display(Name = "Vareta - ØI mm")]
        public int VaretaDiamI { get; set; }

        [StringLength(8)]
        public string Medidas { get; set; }

        [Display(Name = "Comprimento mm")]
        public int Comprimento { get; set; }

        [Display(Name = "T.U.P. min")]
        public int Tup { get; set; }

        [Display(Name = "Prensa Pré-Forma")]
        public int PrensaPreFormaId { get; set; }

        public PrensaPreForma PrensaPreForma { get; set; }

        [Display(Name = "Preparo (min)")]
        public int Preparo { get; set; }

        [Display(Name = "Troca PF (min)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float TrocaPf { get; set; }

        [Display(Name = "Extrusora")]
        public int ExtrusoraId { get; set; }

        public Extrusora Extrusora { get; set; }

        [Display(Name = "Seçãoda PF")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float SecaoPf { get; set; }

        [Display(Name = "Kgf Prensagem")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float KgfPrensagem { get; set; }

        [Display(Name = "Pressão Óleo")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float PressaoOleo { get; set; }

        [Display(Name = "Ø Pistão Hidráulico")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public float DiamPistaoHidraulico { get; set; }

        [Display(Name = "Kg PF úmida")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public float KgPfUmida { get; set; }
    }
}