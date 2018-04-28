using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Models
{
    public class Parametro
    {
        public int Id { get; set; }

        [Display(Name = "Dólar")]
        public float Dolar { get; set; }

        [Display(Name = "Proporção Fios e Gaxetas")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float PropFitasFioGaxeta { get; set; } // Proporção do custo dos sub-produtos de PTFE Puro destinados a Fios & Gaxetas que é assimilado pela linha de Fitas

        [Display(Name = "Proporção Sucatas Vendáveis")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float PropSucatas { get; set; } // Proporção do custo das sucatas vendáveis de PTFE Puro que é assimilado pela linha de Fitas

        [Display(Name = "Proporção Grafitados")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float PropGrafitado { get; set; } // Proporção do custo dos sub-produtos de PTFE Grafitado destinados a Fios & Gaxetas que é assimilado pela linha de Fitas Grafitadas

        [Display(Name = "Horas Disponíveis de MOD")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int HMod { get; set; }

        [Display (Name = "Custo Fixo Industrial em Um Ano")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float CustoFixoIndustrialAno { get; set; }

        [Display(Name = "Custo Fixo Comercial em Um Ano")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float CustoFixoComercialAno { get; set; }

        [Display(Name = "Custo Fixo Comercial COMTEX em Um Ano")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float CustoFixoComtexAno { get; set; }

        [Display(Name = "Custo Fixo Administrativo em Um Ano")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float CustoFixoAdminAno { get; set; }

        [Display(Name = "Custo Folha MOD em Um Ano")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public float CustoFolhaModAno { get; set; }

        [Display(Name = "Semanas de Reposição")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int SemanasReposicao { get; set; }

        [Display(Name = "Comissão GC-COMACS")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float ComissaoGcComacs { get; set; }

        [Display(Name = "ICMS")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public float Icms { get; set; }

        [Display(Name = "IPI")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public float Ipi { get; set; }

        [Display(Name = "INSS")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float Inss { get; set; }

        [Display(Name = "Comissão")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public float Comissão { get; set; }

        [Display(Name = "Frete")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float Frete { get; set; }

        [Display(Name = "Margem Líquida")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public float MargemLiquida { get; set; }

        [Display(Name = "Comissão Gestão de Vendas")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float ComissGestVenda { get; set; }

        [Display(Name = "Condição Pagamento Padrão")]
        public float CondicaoPgtoStd { get; set; }

        [Display(Name = "Taxa Juros Padrão")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float TxJuroStd { get; set; }

        [Display(Name = "Custo Financeiro")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float CustoFin { get; set; }

        [Display(Name = "Custo Cobrança")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public float CustoCobranca { get; set; }
    }
}