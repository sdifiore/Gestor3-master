using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class CustoFolha
    {
        public int CustoFolhaId { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Display(Name = "Salários brutos")]
        [DataType(DataType.Currency)]
        public float Salario { get; set; }

        [Display(Name = "Férias")]
        [DataType(DataType.Currency)]
        public float Ferias { get; set; }

        [Display(Name = "13º")]
        [DataType(DataType.Currency)]
        public float DecimoTerceiro { get; set; }

        [Display(Name = "PLR")]
        [DataType(DataType.Currency)]
        public float Plr { get; set; }

        [Display(Name = "FGTS")]
        [DataType(DataType.Currency)]
        public float Fgts { get; set; }

        [Display(Name = "INSS")]
        [DataType(DataType.Currency)]
        public float Inss { get; set; }

        [Display(Name = "Desp. Agência")]
        [DataType(DataType.Currency)]
        public float DespAgencia { get; set; }

        [Display(Name = "Conv. Médico")]
        [DataType(DataType.Currency)]
        public float ConvMedico { get; set; }

        [Display(Name = "Vale Alimentação")]
        [DataType(DataType.Currency)]
        public float VAlimentacao { get; set; }

        [Display(Name = "Vale Transporte")]
        [DataType(DataType.Currency)]
        public float VTransporte { get; set; }

        [Display(Name = "Área")]
        public int AreaId { get; set; }

        public Area Area { get; set; }
    }
}