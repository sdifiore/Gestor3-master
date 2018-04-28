using Gestor.Models;
using System;
using System.Linq;

namespace Gestor
{
    public static class FxPrecoExportacao
    {
        public static float De2A5(PrecoExportacao preco)        // F
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var indices = db.Indices;
                float dolar = db.Parametros.First().Dolar;
                float incrLl = db.DespesasExportacao.Single(d => d.Tipo == "LL").Valor;
                float x = 0;
                float y = preco.DespExpPadrao
                    ? db.DespesasExportacao.Single(d => d.Tipo == "1").Valor
                    : preco.PctDespExportEspec;
                float z = preco.QtUnid == 0 ? 1 : preco.QtUnid;

                if (preco.CondicaoPreco.Apelido != "EXW")
                {
                    if (preco.CondicaoPreco.Apelido != "FOB") x = preco.PctEspecFrete;
                    else
                    {
                        string temp = XmlReader.Read("FreteNacionalPadrao");
                        x = indices.Single(i => i.Descricao == temp).Exportacao;
                    }
                }

                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.PctRateio) * 0.674f /
                    (0.674f * (1 - preco.Com -
                    x -
                    preco.IEfetiva - y) -
                    (preco.LlMin + 3 * incrLl)) /
                    z / dolar; 
            }

            return result;
        }

        public static float De5A10(PrecoExportacao preco)       // G
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var indices = db.Indices;
                float x = 0;
                float y = preco.DespExpPadrao
                    ? db.DespesasExportacao.Single(d => d.Tipo == "2").Valor
                    : preco.PctDespExportEspec;
                float z = preco.QtUnid == 0 ? 1 : preco.QtUnid;

                if (preco.CondicaoPreco.Apelido != "EXW")
                {
                    if (preco.CondicaoPreco.Apelido != "FOB") x = preco.PctEspecFrete;
                    else
                    {
                        string temp = XmlReader.Read("FreteNacionalPadrao");
                        x = indices.Single(i => i.Descricao == temp).Exportacao;
                    }
                }

                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.PctRateio) * 0.674f /
                    (0.674f * (1 - preco.Com -
                    x -
                    preco.IEfetiva - y) -
                    (preco.LlMin + 2 * db.DespesasExportacao.Single(d => d.Tipo == "LL").Valor)) /
                    z / db.Parametros.First().Dolar; 
            }

            return result;
        }

        public static float De10A20(PrecoExportacao preco)      // H
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var indices = db.Indices;
                float x = 0;
                float y = preco.DespExpPadrao
                    ? db.DespesasExportacao.Single(d => d.Tipo == "3").Valor
                    : preco.PctDespExportEspec;
                float z = preco.QtUnid == 0 ? 1 : preco.QtUnid;

                if (preco.CondicaoPreco.Apelido != "EXW")
                {
                    if (preco.CondicaoPreco.Apelido != "FOB") x = preco.PctEspecFrete;
                    else
                    {
                        string temp = XmlReader.Read("FreteNacionalPadrao");
                        x = indices.Single(i => i.Descricao == temp).Exportacao;
                    }
                }

                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.PctRateio) * 0.674f /
                    (0.674f * (1 - preco.Com -
                    x -
                    preco.IEfetiva - y) -
                    (preco.LlMin + db.DespesasExportacao.Single(d => d.Tipo == "LL").Valor)) /
                    z / db.Parametros.First().Dolar; 
            }

            return result;
        }

        public static float Acima20(PrecoExportacao preco)      // I
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var indices = db.Indices;
                float x = 0;
                float y = preco.DespExpPadrao
                    ? db.DespesasExportacao.Single(d => d.Tipo == "4").Valor
                    : preco.PctDespExportEspec;
                float z = preco.QtUnid == 0 ? 1 : preco.QtUnid;

                if (preco.CondicaoPreco.Apelido != "EXW")
                {
                    if (preco.CondicaoPreco.Apelido != "FOB") x = preco.PctEspecFrete;
                    else
                    {
                        string temp = XmlReader.Read("FreteNacionalPadrao");
                        x = indices.Single(i => i.Descricao == temp).Exportacao;
                    }
                }

                result = (preco.CustoDireto + preco.RateioCustoFixo * preco.PctRateio) * 0.674f /
                    (0.674f * (1 - preco.Com -
                    x -
                    preco.IEfetiva - y) -
                    preco.LlMin) /
                    z / db.Parametros.First().Dolar; 
            }

            return result;
        }

        public static float IEfetiva(PrecoExportacao preco)     // O
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var indices = db.Indices;
                string temp = XmlReader.Read("Taxa30DDL");
                float taxa = indices.Single(i => i.Descricao == temp).Proprio;
                result = (float)Math.Pow(Math.Pow(1 + taxa, 1 / 30), preco.CondPag) - 1; 
            }

            return result;
        }

        public static float PvFobMax(PrecoExportacao preco)     // S
        {
            float result = Math.Abs(preco.De2A5) > Global.Tolerance
                ? (float)Math.Round(preco.De2A5 * preco.QtUnid, 2)
                : 0;

            return result;
        }

        public static float PvFobMin(PrecoExportacao preco)     // V
        {
            float result = Math.Abs(preco.Acima20) > Global.Tolerance
                ? (float)Math.Round(preco.Acima20 * preco.QtUnid, 2)
                : 0;

            return result;
        }

        public static float ValorCifPtfe(PrecoExportacao preco)     // W
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var produto = db.Produtos.SingleOrDefault(p => p.Apelido == preco.Apelido);
                float referencia = db.DespesasExportacao.Single(d => d.Tipo == "Ref").Valor;
                float prod = produto == null
                    ? 0
                    : produto.PctPtfePeso;
                result = (float)Math.Round(preco.PesoLiquido * prod * referencia, 3); 
            }

            return result;
        }

        public static float RelPtfeSobrePv(PrecoExportacao preco)
        {
            float result = Math.Abs(preco.PvFobMin) < Global.Tolerance
                ? 0
                : preco.ValorCifPtfe / preco.PvFobMin;

            return result;
        }
    }
}