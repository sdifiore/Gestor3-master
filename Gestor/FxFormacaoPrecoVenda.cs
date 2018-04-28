using Gestor.Models;
using System;
using System.Linq;

namespace Gestor
{
    public static class FxFormacaoPrecoVenda
    {
        public static float Fpv0Total()        //C20
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                float gr15 = db.GruposRateio.Single(g => g.Apelido == "GR0015").Fiotec;
                float gr09 = db.GruposRateio.Single(g => g.Apelido == "GR0009").Fita;

                result = Math.Round(gr09) > Global.Tolerance
                    ? gr15 / gr09
                    : 0;
            }

            return result;
        }

        public static float Fpv0MoiFabricao(float custo)        //D20
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string cRateio = XmlReader.Read("PessoalIndiretoFabrica");
                string cTotal = XmlReader.Read("DespesaTotalCustoFixo");
                float rateio = db.DespesasFixas.Single(d => d.Despesa == cRateio).RateioFiotec;
                float total = db.DespesasFixas.Single(d => d.Despesa == cTotal).RateioFiotec;
                result = Math.Abs(total) > Global.Tolerance
                    ? custo * rateio / total
                    : 0;
            }

            return result;
        }

        public static float Fpv0Outro(float custo)      //E20
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH20 = XmlReader.Read("ServicoTerceiroFabrica");
                string compH25 = XmlReader.Read("ManutencaoIndustrial");
                string compH29 = XmlReader.Read("OutrasDespesasIndiretasFabrica");
                string compH39 = XmlReader.Read("EnergiaAguaEsgoto");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h20 = db.DespesasFixas.Single(d => d.Despesa == compH20).RateioFiotec;
                float h25 = db.DespesasFixas.Single(d => d.Despesa == compH25).RateioFiotec;
                float h29 = db.DespesasFixas.Single(d => d.Despesa == compH29).RateioFiotec;
                float h39 = db.DespesasFixas.Single(d => d.Despesa == compH39).RateioFiotec;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFiotec;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * (h20 + h25 + h29 + h39) / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv0Comacs(float custo)     //F20
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH42 = XmlReader.Read("CustoFixoComGeral");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h42 = db.DespesasFixas.Single(d => d.Despesa == compH42).RateioFiotec;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFiotec;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h42 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv0Comex(float custo)     //G20
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH77 = XmlReader.Read("CustoFixoComComex");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h77 = db.DespesasFixas.Single(d => d.Despesa == compH77).RateioFiotec;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFiotec;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h77 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv0Adm(float custo)     //H20
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH115 = XmlReader.Read("CustoFixoAdmin");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h115 = db.DespesasFixas.Single(d => d.Despesa == compH115).RateioFiotec;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFiotec;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h115 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv1Total()        //C21
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                float gr15 = db.GruposRateio.Single(g => g.Apelido == "GR0015").Fita;
                float gr09 = db.GruposRateio.Single(g => g.Apelido == "GR0009").Fita;

                result = Math.Round(gr09) > Global.Tolerance
                    ? gr15 / gr09
                    : 0;
            }

            return result;
        }

        public static float Fpv1MoiFabricao(float custo)        //D21
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string cRateio = XmlReader.Read("PessoalIndiretoFabrica");
                string cTotal = XmlReader.Read("DespesaTotalCustoFixo");
                float rateio = db.DespesasFixas.Single(d => d.Despesa == cRateio).RateioFitas;
                float total = db.DespesasFixas.Single(d => d.Despesa == cTotal).RateioFitas;
                result = Math.Abs(total) > Global.Tolerance
                    ? custo * rateio / total
                    : 0;
            }

            return result;
        }

        public static float Fpv1Outro(float custo)      //E21
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH20 = XmlReader.Read("ServicoTerceiroFabrica");
                string compH25 = XmlReader.Read("ManutencaoIndustrial");
                string compH29 = XmlReader.Read("OutrasDespesasIndiretasFabrica");
                string compH39 = XmlReader.Read("EnergiaAguaEsgoto");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h20 = db.DespesasFixas.Single(d => d.Despesa == compH20).RateioFitas;
                float h25 = db.DespesasFixas.Single(d => d.Despesa == compH25).RateioFitas;
                float h29 = db.DespesasFixas.Single(d => d.Despesa == compH29).RateioFitas;
                float h39 = db.DespesasFixas.Single(d => d.Despesa == compH39).RateioFitas;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFitas;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * (h20 + h25 + h29 + h39) / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv1Comacs(float custo)     //F21
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH42 = XmlReader.Read("CustoFixoComGeral");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h42 = db.DespesasFixas.Single(d => d.Despesa == compH42).RateioFitas;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFitas;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h42 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv1Comex(float custo)     //G21
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH77 = XmlReader.Read("CustoFixoComComex");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h77 = db.DespesasFixas.Single(d => d.Despesa == compH77).RateioFitas;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFitas;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h77 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv1Adm(float custo)     //H21
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH115 = XmlReader.Read("CustoFixoAdmin");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h115 = db.DespesasFixas.Single(d => d.Despesa == compH115).RateioFitas;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFitas;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h115 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv2Total()        //C22
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                float gr15 = db.GruposRateio.Single(g => g.Apelido == "GR0015").Graxa;
                float gr09 = db.GruposRateio.Single(g => g.Apelido == "GR0009").Fita;

                result = Math.Round(gr09) > Global.Tolerance
                    ? gr15 / gr09
                    : 0;
            }

            return result;
        }

        public static float Fpv2MoiFabricao(float custo)        //D22
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string cRateio = XmlReader.Read("PessoalIndiretoFabrica");
                string cTotal = XmlReader.Read("DespesaTotalCustoFixo");
                float rateio = db.DespesasFixas.Single(d => d.Despesa == cRateio).RateioGraxa;
                float total = db.DespesasFixas.Single(d => d.Despesa == cTotal).RateioGraxa;
                result = Math.Abs(total) > Global.Tolerance
                    ? custo * rateio / total
                    : 0;
            }

            return result;
        }

        public static float Fpv2Outro(float custo)      //E22
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH20 = XmlReader.Read("ServicoTerceiroFabrica");
                string compH25 = XmlReader.Read("ManutencaoIndustrial");
                string compH29 = XmlReader.Read("OutrasDespesasIndiretasFabrica");
                string compH39 = XmlReader.Read("EnergiaAguaEsgoto");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h20 = db.DespesasFixas.Single(d => d.Despesa == compH20).RateioGraxa;
                float h25 = db.DespesasFixas.Single(d => d.Despesa == compH25).RateioGraxa;
                float h29 = db.DespesasFixas.Single(d => d.Despesa == compH29).RateioGraxa;
                float h39 = db.DespesasFixas.Single(d => d.Despesa == compH39).RateioGraxa;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioGraxa;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * (h20 + h25 + h29 + h39) / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv2Comacs(float custo)     //F22
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH42 = XmlReader.Read("CustoFixoComGeral");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h42 = db.DespesasFixas.Single(d => d.Despesa == compH42).RateioGraxa;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioGraxa;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h42 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv2Comex(float custo)     //G22
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH77 = XmlReader.Read("CustoFixoComComex");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h77 = db.DespesasFixas.Single(d => d.Despesa == compH77).RateioGraxa;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioGraxa;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h77 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv2Adm(float custo)     //H22
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH115 = XmlReader.Read("CustoFixoAdmin");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h115 = db.DespesasFixas.Single(d => d.Despesa == compH115).RateioGraxa;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioGraxa;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h115 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv3Total()        //C23
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                float gr15 = db.GruposRateio.Single(g => g.Apelido == "GR0015").Gxgraf;
                float gr09 = db.GruposRateio.Single(g => g.Apelido == "GR0009").Fita;

                result = Math.Round(gr09) > Global.Tolerance
                    ? gr15 / gr09
                    : 0;
            }

            return result;
        }

        public static float Fpv3MoiFabricao(float custo)        //D23
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string cRateio = XmlReader.Read("PessoalIndiretoFabrica");
                string cTotal = XmlReader.Read("DespesaTotalCustoFixo");
                float rateio = db.DespesasFixas.Single(d => d.Despesa == cRateio).RateioFioGaxPtfeGraf;
                float total = db.DespesasFixas.Single(d => d.Despesa == cTotal).RateioFioGaxPtfeGraf;
                result = Math.Abs(total) > Global.Tolerance
                    ? custo * rateio / total
                    : 0;
            }

            return result;
        }

        public static float Fpv3Outro(float custo)      //E23
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH20 = XmlReader.Read("ServicoTerceiroFabrica");
                string compH25 = XmlReader.Read("ManutencaoIndustrial");
                string compH29 = XmlReader.Read("OutrasDespesasIndiretasFabrica");
                string compH39 = XmlReader.Read("EnergiaAguaEsgoto");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h20 = db.DespesasFixas.Single(d => d.Despesa == compH20).RateioFioGaxPtfeGraf;
                float h25 = db.DespesasFixas.Single(d => d.Despesa == compH25).RateioFioGaxPtfeGraf;
                float h29 = db.DespesasFixas.Single(d => d.Despesa == compH29).RateioFioGaxPtfeGraf;
                float h39 = db.DespesasFixas.Single(d => d.Despesa == compH39).RateioFioGaxPtfeGraf;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfeGraf;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * (h20 + h25 + h29 + h39) / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv3Comacs(float custo)     //F23
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH42 = XmlReader.Read("CustoFixoComGeral");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h42 = db.DespesasFixas.Single(d => d.Despesa == compH42).RateioFioGaxPtfeGraf;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfeGraf;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h42 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv3Comex(float custo)     //G23
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH77 = XmlReader.Read("CustoFixoComComex");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h77 = db.DespesasFixas.Single(d => d.Despesa == compH77).RateioFioGaxPtfeGraf;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfeGraf;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h77 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv3Adm(float custo)     //H23
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH115 = XmlReader.Read("CustoFixoAdmin");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h115 = db.DespesasFixas.Single(d => d.Despesa == compH115).RateioFioGaxPtfeGraf;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfeGraf;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h115 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv4Total()        //C24
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                float gr15 = db.GruposRateio.Single(g => g.Apelido == "GR0015").Gxpuro;
                float gr09 = db.GruposRateio.Single(g => g.Apelido == "GR0009").Fita;

                result = Math.Round(gr09) > Global.Tolerance
                    ? gr15 / gr09
                    : 0;
            }

            return result;
        }

        public static float Fpv4MoiFabricao(float custo)        //D24
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string cRateio = XmlReader.Read("PessoalIndiretoFabrica");
                string cTotal = XmlReader.Read("DespesaTotalCustoFixo");
                float rateio = db.DespesasFixas.Single(d => d.Despesa == cRateio).RateioFioGaxPtfePuro;
                float total = db.DespesasFixas.Single(d => d.Despesa == cTotal).RateioFioGaxPtfePuro;
                result = Math.Abs(total) > Global.Tolerance
                    ? custo * rateio / total
                    : 0;
            }

            return result;
        }

        public static float Fpv4Outro(float custo)      //E24
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH20 = XmlReader.Read("ServicoTerceiroFabrica");
                string compH25 = XmlReader.Read("ManutencaoIndustrial");
                string compH29 = XmlReader.Read("OutrasDespesasIndiretasFabrica");
                string compH39 = XmlReader.Read("EnergiaAguaEsgoto");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h20 = db.DespesasFixas.Single(d => d.Despesa == compH20).RateioFioGaxPtfePuro;
                float h25 = db.DespesasFixas.Single(d => d.Despesa == compH25).RateioFioGaxPtfePuro;
                float h29 = db.DespesasFixas.Single(d => d.Despesa == compH29).RateioFioGaxPtfePuro;
                float h39 = db.DespesasFixas.Single(d => d.Despesa == compH39).RateioFioGaxPtfePuro;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfePuro;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * (h20 + h25 + h29 + h39) / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv4Comacs(float custo)     //F24
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH42 = XmlReader.Read("CustoFixoComGeral");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h42 = db.DespesasFixas.Single(d => d.Despesa == compH42).RateioFioGaxPtfePuro;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfePuro;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h42 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv4Comex(float custo)     //G24
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH77 = XmlReader.Read("CustoFixoComComex");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h77 = db.DespesasFixas.Single(d => d.Despesa == compH77).RateioFioGaxPtfePuro;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfePuro;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h77 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv4Adm(float custo)     //H24
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH115 = XmlReader.Read("CustoFixoAdmin");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h115 = db.DespesasFixas.Single(d => d.Despesa == compH115).RateioFioGaxPtfePuro;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioFioGaxPtfePuro;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h115 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv5Total()        //C25
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                float gr15 = db.GruposRateio.Single(g => g.Apelido == "GR0015").Revenda;
                float gr09 = db.GruposRateio.Single(g => g.Apelido == "GR0009").Fita;

                result = Math.Round(gr09) > Global.Tolerance
                    ? gr15 / gr09
                    : 0;
            }

            return result;
        }

        public static float Fpv5MoiFabricao(float custo)        //D25
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string cRateio = XmlReader.Read("PessoalIndiretoFabrica");
                string cTotal = XmlReader.Read("DespesaTotalCustoFixo");
                float rateio = db.DespesasFixas.Single(d => d.Despesa == cRateio).RateioRevenda;
                float total = db.DespesasFixas.Single(d => d.Despesa == cTotal).RateioRevenda;
                result = Math.Abs(total) > Global.Tolerance
                    ? custo * rateio / total
                    : 0;
            }

            return result;
        }

        public static float Fpv5Outro(float custo)      //E25
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH20 = XmlReader.Read("ServicoTerceiroFabrica");
                string compH25 = XmlReader.Read("ManutencaoIndustrial");
                string compH29 = XmlReader.Read("OutrasDespesasIndiretasFabrica");
                string compH39 = XmlReader.Read("EnergiaAguaEsgoto");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h20 = db.DespesasFixas.Single(d => d.Despesa == compH20).RateioRevenda;
                float h25 = db.DespesasFixas.Single(d => d.Despesa == compH25).RateioRevenda;
                float h29 = db.DespesasFixas.Single(d => d.Despesa == compH29).RateioRevenda;
                float h39 = db.DespesasFixas.Single(d => d.Despesa == compH39).RateioRevenda;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioRevenda;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * (h20 + h25 + h29 + h39) / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv5Comacs(float custo)     //F25
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH42 = XmlReader.Read("CustoFixoComGeral");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h42 = db.DespesasFixas.Single(d => d.Despesa == compH42).RateioRevenda;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioRevenda;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h42 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv5Comex(float custo)     //G25
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH77 = XmlReader.Read("CustoFixoComComex");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h77 = db.DespesasFixas.Single(d => d.Despesa == compH77).RateioRevenda;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioRevenda;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h77 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv5Adm(float custo)     //H25
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH115 = XmlReader.Read("CustoFixoAdmin");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h115 = db.DespesasFixas.Single(d => d.Despesa == compH115).RateioRevenda;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioRevenda;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h115 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv6Total()        //C26
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                float gr15 = db.GruposRateio.Single(g => g.Apelido == "GR0015").Tubo;
                float gr09 = db.GruposRateio.Single(g => g.Apelido == "GR0009").Fita;

                result = Math.Round(gr09) > Global.Tolerance
                    ? gr15 / gr09
                    : 0;
            }

            return result;
        }

        public static float Fpv6MoiFabricao(float custo)        //D26
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string cRateio = XmlReader.Read("PessoalIndiretoFabrica");
                string cTotal = XmlReader.Read("DespesaTotalCustoFixo");
                float rateio = db.DespesasFixas.Single(d => d.Despesa == cRateio).RateioTuboCordaoPerfil;
                float total = db.DespesasFixas.Single(d => d.Despesa == cTotal).RateioTuboCordaoPerfil;
                result = Math.Abs(total) > Global.Tolerance
                    ? custo * rateio / total
                    : 0;
            }

            return result;
        }

        public static float Fpv6Outro(float custo)      //E26
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH20 = XmlReader.Read("ServicoTerceiroFabrica");
                string compH25 = XmlReader.Read("ManutencaoIndustrial");
                string compH29 = XmlReader.Read("OutrasDespesasIndiretasFabrica");
                string compH39 = XmlReader.Read("EnergiaAguaEsgoto");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h20 = db.DespesasFixas.Single(d => d.Despesa == compH20).RateioTuboCordaoPerfil;
                float h25 = db.DespesasFixas.Single(d => d.Despesa == compH25).RateioTuboCordaoPerfil;
                float h29 = db.DespesasFixas.Single(d => d.Despesa == compH29).RateioTuboCordaoPerfil;
                float h39 = db.DespesasFixas.Single(d => d.Despesa == compH39).RateioTuboCordaoPerfil;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioTuboCordaoPerfil;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * (h20 + h25 + h29 + h39) / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv6Comacs(float custo)     //F26
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH42 = XmlReader.Read("CustoFixoComGeral");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h42 = db.DespesasFixas.Single(d => d.Despesa == compH42).RateioTuboCordaoPerfil;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioTuboCordaoPerfil;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h42 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv6Comex(float custo)     //G26
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH77 = XmlReader.Read("CustoFixoComComex");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h77 = db.DespesasFixas.Single(d => d.Despesa == compH77).RateioTuboCordaoPerfil;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioTuboCordaoPerfil;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h77 / h201
                   : 0;
            }

            return result;
        }

        public static float Fpv6Adm(float custo)     //H26
        {
            float result;

            using (var db = new ApplicationDbContext())
            {
                string compH115 = XmlReader.Read("CustoFixoAdmin");
                string compH201 = XmlReader.Read("DespesaTotalCustoFixo");
                float h115 = db.DespesasFixas.Single(d => d.Despesa == compH115).RateioTuboCordaoPerfil;
                float h201 = db.DespesasFixas.Single(d => d.Despesa == compH201).RateioTuboCordaoPerfil;
                result = Math.Abs(h201) > Global.Tolerance
                   ? custo * h115 / h201
                   : 0;
            }

            return result;
        }
    }
}