using Gestor.Models;
using System.Linq;

namespace Gestor
{
    public static class FxPrecoNacional
    {
        public static float I18Nivel1(PrecoNacional preco)      // G
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "18").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (db.IcmsFretes.Single(i => i.Rotulo == "18").Frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - (preco.LlMin + 2 * 0.03f) *      // 0.03f = Incr.LL 3,00%
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I18Nivel2(PrecoNacional preco)      // H
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "18").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                float frete = db.IcmsFretes.Single(i => i.Rotulo == "18").Frete;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - (preco.LlMin + 0.03f) *      // 0.03f = Incr.LL 3,00%
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I18Nivel3(PrecoNacional preco)      // I
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "18").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                float frete = db.IcmsFretes.Single(i => i.Rotulo == "18").Frete;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - preco.LlMin *
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I12Nivel1(PrecoNacional preco)      // J
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "12").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (db.IcmsFretes.Single(i => i.Rotulo == "12").Frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - (preco.LlMin + 2 * 0.03f) *      // 0.03f = Incr.LL 3,00%
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I12Nivel2(PrecoNacional preco)      // k
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "12").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (db.IcmsFretes.Single(i => i.Rotulo == "12").Frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - (preco.LlMin + 0.03f) *      // 0.03f = Incr.LL 3,00%
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I12Nivel3(PrecoNacional preco)      // L
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "12").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                float frete = db.IcmsFretes.Single(i => i.Rotulo == "12").Frete;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - preco.LlMin *
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I7Nivel1(PrecoNacional preco)      // M
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "7").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (db.IcmsFretes.Single(i => i.Rotulo == "7").Frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - (preco.LlMin + 2 * 0.03f) *      // 0.03f = Incr.LL 3,00%
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I7Nivel2(PrecoNacional preco)      // N
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "7").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (db.IcmsFretes.Single(i => i.Rotulo == "7").Frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - (preco.LlMin + 0.03f) *      // 0.03f = Incr.LL 3,00%
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }

        public static float I7Nivel3(PrecoNacional preco)      // O
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string indice = XmlReader.Read("IndiceGestaoVenda");
                float indiceGestao = db.Indices.Single(i => i.Descricao == indice).Terceiros;
                string taxa = XmlReader.Read("TaxaEfetivaVendaNacional");
                float taxaEfetiva = db.Indices.Single(i => i.Descricao == taxa).Proprio;
                string despesa = XmlReader.Read("DespesaCobranca");
                float despesaCobranca = db.Indices.Single(i => i.Descricao == despesa).Proprio;
                float temp = preco.TipoProducao.Descricao == "IND" ? db.IcmsFretes.Single(i => i.Rotulo == "7").Icms : 0;
                float temp2 = preco.QtUnid == 0 ? 1 : preco.QtUnid;
                float frete = db.IcmsFretes.Single(i => i.Rotulo == "7").Frete;
                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.AplicRoteiro) * 0.66f /
                    (0.66f * (1 - temp - 0.0925f - preco.Com - indiceGestao -
                    (frete + taxaEfetiva + despesaCobranca) *
                    (1 + preco.Ipi)) - preco.LlMin *
                    (1 - temp - 0.0925f)) / temp2; 
            }

            return result;
        }
    }
}