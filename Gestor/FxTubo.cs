using System.Linq;
using Gestor.Models;
using System;

namespace Gestor
{
    public static class FxTubo
    {
        public static float ResinaAdotada(ProcTubo procTubo)        // L
        {
            string resinaBase = XmlReader.Read("Transl");
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                if (procTubo.ResinaBase.Apelido == resinaBase)
                {
                    string comp = XmlReader.Read("PadraoFixo19");
                    result = db.PadroesFixos.SingleOrDefault(pf => pf.Descricao == comp).Valor;
                }

                else
                {
                    resinaBase = XmlReader.Read("BrancoB");

                    if (procTubo.ResinaBase.Apelido == resinaBase)
                    {
                        string comp = XmlReader.Read("PadraoFixo17");
                        result = db.PadroesFixos.SingleOrDefault(pf => pf.Descricao == comp).Valor;
                    }

                    else
                    {
                        string comp = XmlReader.Read("PadraoFixo18");
                        result = db.PadroesFixos.SingleOrDefault(pf => pf.Descricao == comp).Valor;
                    }
                } 
            }

            return result;
        }


        public static float RrMaxResina(ProcTubo procTubo)      // M
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var resina = db.ResinasPtfe.SingleOrDefault(r => r.Ref == procTubo.CodResinaAdotada);
                if (resina == null) DbLogger.Log(Reason.Error, $"Resina {procTubo.CodResinaAdotada} não encontrada em RrMaxResina");
                else result = resina.MaxRr; 
            }

            return result;
        }

        public static float BicoIdeal(ProcTubo procTubo)
        {
            float result = 0;

            if (procTubo.Sinterizado)
            {
                result = procTubo.ResinaBase.Apelido == XmlReader.Read("Branco")
                    ? 0.97f
                    : 0.93f;
            }

            else result = 1;

            return Function.Ceiling(procTubo.DiamExterno / result, 0.05f);
        }

        public static float MandrilIdeal(ProcTubo procTubo)
        {
            float result = 0;

            if (procTubo.Sinterizado)
            {
                result = procTubo.ResinaBase.Apelido == XmlReader.Read("Branco")
                    ? 0.97f
                    : 0.93f;
            }

            else result = 1;

            return Function.Ceiling(procTubo.DiamInterno / result, 0.05f);
        }

        public static float SecaoExtrudado(ProcTubo procTubo)
        {
            return (procTubo.BicoIdeal * procTubo.BicoIdeal - procTubo.MandrilIdeal * procTubo.MandrilIdeal) * (float)Math.PI / 4f;
        }

        public static float PerimSecaoExtrud(ProcTubo procTubo)     // Q
        {
            float result = procTubo.Cadastro != "--"
                ? procTubo.BicoIdeal * (float)Math.PI / ((procTubo.BicoIdeal * procTubo.BicoIdeal - procTubo.MandrilIdeal * procTubo.MandrilIdeal) * (float)Math.PI / 4f)
                : 0;

            //float result = procTubo.BicoIdeal * (float)Math.PI / ((procTubo.BicoIdeal * procTubo.BicoIdeal - 
            //    procTubo.MandrilIdeal * procTubo.MandrilIdeal) * (float)Math.PI / 4f);

            return result;
        }

        public static float DiamExtFinalTubo(ProcTubo procTubo)     // R
        {
            float result = 0;

            if (procTubo.Cadastro != "--")
            {
                if (procTubo.Sinterizado)
                {
                    result = procTubo.ResinaBase.Apelido == XmlReader.Read("Branco")
                        ? 0.97f
                        : 0.93f;
                }

                else result = 1;
            }

            return procTubo.BicoIdeal * result;
        }

        public static float DiamIntFinalTubo(ProcTubo procTubo)     //~S
        {
            float result = 0;

            if (procTubo.Cadastro != "--")
            {
                if (procTubo.Sinterizado)
                {
                    result = procTubo.ResinaBase.Apelido == XmlReader.Read("Branco")
                        ? 0.97f
                        : 0.93f;
                }

                else result = 1;
            }

            return procTubo.MandrilIdeal * result;
        }

        public static float PesoUnKgMLiq(ProcTubo procTubo)     // T
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                float intermidiate = (procTubo.DiamExtFinalTubo * procTubo.DiamExtFinalTubo - procTubo.DiamIntFinalTubo * procTubo.DiamIntFinalTubo) * (float)Math.PI / 4f;
                string densCordao = XmlReader.Read("DensidadeCordaoSeco");
                string densPadrao = XmlReader.Read("DensidadePadraoSinterizado");
                result = !procTubo.Sinterizado
                    ? intermidiate * db.PadroesFixos.Single(p => p.Descricao == densCordao).Valor / 1_000f
                    : intermidiate * db.PadroesFixos.Single(p => p.Descricao == densPadrao).Valor / 1_000f; 
            }

            return result;
        }

        public static float PtfeKgM(ProcTubo procTubo)      // U
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("SucatasAparasTubos");
                var sucata = db.PadroesFixos.Single(p => p.Descricao == comp);
                result = sucata == null
                    ? 0
                    : procTubo.PesoUnKgMLiq / (1f - sucata.Valor) * (1f - procTubo.PctCarga1) * (1f - procTubo.PctCarga2); 
            }

            return result;
        }

        public static float LubrKgM(ProcTubo procTubo)      // V
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("SucatasAparasTubos");
                var sucata = db.PadroesFixos.Single(p => p.Descricao == comp);
                comp = XmlReader.Read("LubrificantePctPadrao");
                var lubrificante = db.PadroesFixos.Single(p => p.Descricao == comp);
                float intermediate = (procTubo.PesoUnKgMLiq / (1 - sucata.Valor)) * lubrificante.Valor;
                int round = intermediate * 1_000f > 10f
                    ? 3
                    : 4;
                result = (float)Math.Round(intermediate, round); 
            }

            return result;
        }

        public static int CodPreformaIdeal(ProcTubo procTubo)     // W
        {
            int result = 0;

            if (procTubo.Cadastro != "--")
            {
                if (7359f / procTubo.SecaoExtrudado <= procTubo.RrMaxResina) result = 5;
                else
                {
                    if (4533f / procTubo.SecaoExtrudado <= procTubo.RrMaxResina) result = 4;
                    else
                    {
                        if (2543f / procTubo.SecaoExtrudado <= procTubo.RrMaxResina) result = 3;
                        else
                        {
                            if (904f / procTubo.SecaoExtrudado <= procTubo.RrMaxResina) result = 2;
                            else result = 1;
                        }
                    }
                }
            }

            return result;
        }

        public static float Rr(ProcTubo procTubo)     // X
        {
            float result = 0;

            if (procTubo.Cadastro != "--")
            {
                using (var db = new ApplicationDbContext())
                {
                    var preforma = db.PreFormas.SingleOrDefault(p => p.PreFormaNum == procTubo.CodPreformaIdeal);
                    if (preforma == null) DbLogger.Log(Reason.Error, $"Preforma {procTubo.CodPreformaIdeal} não encontrada em Rr");
                    else result = (float)Math.Round(preforma.SecaoPf * 100f / procTubo.SecaoExtrudado, 1); 
                }
            }

            return result;
        }

        public static int LanceSinterizado(ProcTubo procTubo)       // Y
        {
            int result = 0;
            using (var db = new ApplicationDbContext())
            {
                if (procTubo.Cadastro != "--")
                {
                    var comprimento = db.PreFormas.SingleOrDefault(p => p.PreFormaNum == procTubo.CodPreformaIdeal);

                    if (comprimento != null)
                    {
                        string comp = XmlReader.Read("SucatasAparasTubos");
                        var sucata = db.PadroesFixos.Single(p => p.Descricao == comp);
                        result = (int)Function.Multiplo((float)Math.Floor(comprimento.Comprimento / 1_000f * procTubo.Rr * (1 - sucata.Valor) * 0.65f), 5);
                    }
                } 
            }

            return result;
        }

        public static float VelEfetExtrusaoMMin(ProcTubo procTubo)      // AO
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                if (!procTubo.ProcessoContinuo)
                {
                    var comprimento = db.PreFormas.SingleOrDefault(p => p.PreFormaNum == procTubo.CodPreformaIdeal);

                    if (comprimento != null)
                    {
                        result = procTubo.LanceSinterizado / (comprimento.Comprimento / 1_000f * procTubo.Rr / (procTubo.VextrUmidoMin * procTubo.FatorMultiplVExter) + comprimento.TrocaPf);
                    }
                } 
            }

            return result;
        }

        public static float VextrUmidoMin(ProcTubo procTubo)        // AE
        {
            float result = 0;

            if (procTubo.Cadastro != "--")
            {
                result = (float)Math.Round(-3.7755f * Math.Log10(procTubo.BicoIdeal) + 18.609f);
            }

            return result;
        }

        public static float VsintMMin(ProcTubo procTubo)        // AG
        {
            float intermidiate = procTubo.Sinterizado ? 1 : 2;

            return (float)Math.Round(0.7862f * Math.Pow(procTubo.PerimSecaoExtrud, 0.9191f) * intermidiate, 1);
        }

        public static float VSintResultante(ProcTubo procTubo)      // AI
        {
            return procTubo.VsintMMin * procTubo.FatorMultiplVelSint;
        }

        public static float TuSinterizadoMinM(ProcTubo procTubo)        // AP
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("OcupacaoMOSinterizacao"); //34
                float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("EficPadraoOpTubo");  //9
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                float intermediate = procTubo.ProcessoContinuo
                    ? 1
                    : ocupacao;
                result = procTubo.VSintResultante > Global.Tolerance
                    ? (float)(Math.Round(1 / procTubo.VSintResultante, 3) / eficacia * intermediate)
                    : float.MaxValue; 
            }

            return result;
        }

        public static float TuProducaoMinM(ProcTubo procTubo)       // AQ
        {
            float result = float.MaxValue;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("EficPadraoOpTubo");
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;

                if (eficacia > Global.Tolerance && procTubo.TuSinterizadoMinM < Global.Infinity)
                {
                    result = procTubo.VelEfetExtrusaoMMin < Global.Tolerance
                    ? procTubo.TuSinterizadoMinM / eficacia
                    : (1 / procTubo.VelEfetExtrusaoMMin + procTubo.TuSinterizadoMinM) / eficacia;
                } 
            }

            return result;
        }

        public static float QtPCusto(ProcTubo procTubo)     // BG
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("LoteMinimoTubos");
                float lote = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                float a = 60 * lote / procTubo.TuProducaoMinM;
                float b = procTubo.LanceSinterizado * procTubo.FatorMultiplQtde;
                float intermediate = a > b ? a : b;
                result = Function.Ceiling(intermediate, procTubo.LanceSinterizado); 
            }

            return result;
        }

        public static int QtPf(ProcTubo procTubo)       // AA
        {
            return (int)Math.Ceiling(procTubo.QtPCusto / procTubo.LanceSinterizado);
        }

        public static float ConfAdtDosLub(ProcTubo procTubo)        // AK
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("EficPadraoOpTubo");   //9
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TaxaOcupacaoMOPesagem"); //32
                float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TempoDosagemLub");   //22
                float tempo = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TempoConferirPeso"); // 24
                float tempoConf = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                float count = 0;
                if (procTubo.Carga1.Apelido != "ND") count++;
                if (procTubo.Carga2.Apelido != "ND") count++;
                if (procTubo.PctCarga1 > Global.Tolerance) count++; 
                result = (count * tempoConf + tempo) / procTubo.QtPCusto / eficacia * ocupacao;
            }

            return result;
        }

        public static float Peneiramento(ProcTubo procTubo)     // AL
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("EficPadraoOpTubo");
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TempoPeneiramento");
                float tempo = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TaxaOcupacaoMOPesagem");
                float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor; 
                result = procTubo.PesoUnKgMLiq * tempo / eficacia * ocupacao;
            }

            return result;
        }

        public static float MisturaMinM(ProcTubo procTubo)      // AM
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("TempoPadraoMistura"); //25
                float tempo = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("EficPadraoOpTubo"); //9
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TempoOcupacaoMOMIstura"); //31
                float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                result = tempo / procTubo.QtPCusto / eficacia * ocupacao;
            }

            return result;
        }

        public static float PreparoExtrusMinM(ProcTubo procTubo)      // AN
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("TempoPadraoPrepExtrusora"); //26
                float tempo = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("EficPadraoOpTubo"); //9
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TaxaOcupacaoMOExtrusora"); //33
                float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor; 
                result = tempo / procTubo.QtPCusto / eficacia * ocupacao;
            }

            return result;
        }

        public static float TuInspUdc3MinM(ProcTubo procTubo)       // AR
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("VelPadraoInspecUDC3"); //37
                float velocidade = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("EficPadraoOpTubo"); //9
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TaxaOcupacaoMOInspecao"); //30
                float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                result = 1 / velocidade / eficacia * ocupacao; 
            }

            return result;
        }

        public static float TuTesteEstanqMinM(ProcTubo procTubo)        // AS
        {
            float result = 0;

            if (procTubo.TesteEstqEsto)
            {
                using (var db = new ApplicationDbContext())
                {
                    string temp = XmlReader.Read("EnsaioEstanque"); //10
                    float ensaio = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    temp = XmlReader.Read("EficPadraoOpTubo"); //9
                    float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    temp = XmlReader.Read("TaxaOcupacaoMOTesteEstanque"); //35
                    float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    result = procTubo.QtPf * ensaio / procTubo.QtPCusto / eficacia * ocupacao; 
                }
            }

            return result;
        }

        public static float TuTesteEstouroMinM(ProcTubo procTubo)        // AT
        {
            float result = 0;

            if (procTubo.TesteEstqEsto)
            {
                using (var db = new ApplicationDbContext())
                {
                    string temp = XmlReader.Read("EnsaioEstouro"); //11
                    float ensaio = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    temp = XmlReader.Read("EficPadraoOpTubo"); //9
                    float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    temp = XmlReader.Read("TaxaOcupacaoMOTesteEstouro"); //35
                    float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    result = ensaio / procTubo.QtPCusto / eficacia * ocupacao; 
                }
            }

            return result;
        }

        public static float TuEmbalMinM(ProcTubo procTubo)        // AU
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("TempoEmbalamento"); //23
                float embalamento = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("EficPadraoOpTubo"); //9
                float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                temp = XmlReader.Read("TaxaOcupacaoEmbalamento"); //28
                float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                float intermediate = Math.Abs(procTubo.QuantEmbalagem) > Global.Tolerance
                    ? (float)Function.Ceiling(procTubo.QtPCusto / procTubo.QuantEmbalagem, 1)
                    : 0;
                result = intermediate * embalamento / procTubo.QtPCusto / eficacia * ocupacao; 
            }

            return result;
        }

        public static float TuTotalMinM(ProcTubo procTubo)      // AV
        {
            float intermediate = 0;

            if (procTubo.VelEfetExtrusaoMMin > Global.Tolerance)
            {
                using (var db = new ApplicationDbContext())
                {
                    string temp = XmlReader.Read("TaxaOcupacaoMOExtrusao"); //29
                    float ocupacao = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    temp = XmlReader.Read("EficPadraoOpTubo"); //9
                    float eficacia = db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                    intermediate = 1 / procTubo.VelEfetExtrusaoMMin * ocupacao / eficacia; 
                }
            }

            return procTubo.ConfAdtDosLub + procTubo.Peneiramento + procTubo.MisturaMinM + 
                procTubo.PreparoExtrusMinM + intermediate + procTubo.TuSinterizadoMinM + 
                procTubo.TuInspUdc3MinM + procTubo.TuTesteEstanqMinM + procTubo.TuTesteEstouroMinM + 
                procTubo.TuEmbalMinM;
        }

        public static float CustoPtfeRsM(ProcTubo procTubo)     // AW
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var resina = db.ResinasPtfe.SingleOrDefault(r => r.Ref == procTubo.CodResinaAdotada);
                float custo = resina == null ? 0 : resina.Custo;
                result = custo * procTubo.PtfeKgM; 
            }

            return result;
        }

        public static float CustoAditivosRsM(ProcTubo procTubo)     // AX
        {
            float a = 0;
            float b = 0;
            float result;
            using (var db = new ApplicationDbContext())
            {
                string temp = XmlReader.Read("SucatasAparasTubos"); //
                float sucatas = 1 - db.PadroesFixos.Single(p => p.Descricao == temp).Valor;
                string naoDefinido = XmlReader.Read("ND");

                if (procTubo.Carga1.Apelido != naoDefinido)
                {
                    int insumoId = db.Aditivos.Single(ad => ad.Carga.Apelido == procTubo.Carga1.Apelido).InsumoId;
                    a = db.Insumos.Single(i => i.InsumoId == insumoId).Custo;
                }

                if (procTubo.Carga2.Apelido != naoDefinido)
                {
                    int insumoId = db.Aditivos.Single(ad => ad.Carga.Apelido == procTubo.Carga2.Apelido).InsumoId;
                    a = db.Insumos.Single(i => i.InsumoId == insumoId).Custo;
                } 

                result = a * procTubo.PctCarga1 * procTubo.PesoUnKgMLiq / sucatas + b * procTubo.PctCarga2 * procTubo.PesoUnKgMLiq / sucatas;
            }

            return result;
        }

        public static float CustoLubrifRsM(ProcTubo procTubo)       // AY
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string isoparL = XmlReader.Read("IsoparL");
                int insumoId = db.Lubrificantes.Single(l => l.Referencia == isoparL).InsumoId;
                float custo = db.Insumos.Single(i => i.InsumoId == insumoId).CustoUndCnsm;
                result = procTubo.LubrKgM * custo;
            }

            return result;
        }

        public static float CustoEmbalRsM(ProcTubo procTubo)        // AZ
        {
            float result = 0;

            if (procTubo.Embalagem.Sigla != XmlReader.Read("ND"))
            {
                using (var db = new ApplicationDbContext())
                {
                    int insumoId = db.Embals.Single(e => e.Id == procTubo.EmbalagemId).InsumoId;
                    result = db.Insumos.Single(i => i.InsumoId == insumoId).CustoUndCnsm / procTubo.QtPCusto; 
                }
            }

            return result;
        }

        public static float CustoModRsM(ProcTubo procTubo)      // BA
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("TubosCordoes");
                float custo = db.CustoCargoDiretos.Single(c => c.Setor.Descricao == comp).CustoUnitario; 
                result = procTubo.TuTotalMinM / 60f * custo;
            }

            return result;
        }

        public static float CustoDiretoTotalRsM(ProcTubo procTubo)      // BB
        {
            return procTubo.CustoPtfeRsM + procTubo.CustoAditivosRsM + procTubo.CustoLubrifRsM + procTubo.CustoEmbalRsM + procTubo.CustoModRsM;
        }

        public static float CustoIndiretoRsM(ProcTubo procTubo)      // BC
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string tubo = XmlReader.Read("GrupoRateioTubo");
                int id = db.GruposRateio.Single(g => g.Descricao == tubo).GrupoRateioId;
                float custo = db.IndiceRateioFormacaoPrecoVendas.Single(i => i.GrupoRateioId == id).TotalCustoFixo;
                result = procTubo.TuTotalMinM / 60 * custo; 
            }

            return result;
        }

        public static float CustoTotalRsM(ProcTubo procTubo)      // BD
        {
            return procTubo.CustoDiretoTotalRsM + procTubo.CustoIndiretoRsM;
        }

        public static float PvRsKg(ProcTubo procTubo)      // BE
        {
            float result = (Math.Abs(procTubo.PesoUnKgMLiq) > Global.Tolerance) && (Math.Abs(procTubo.PvCalculadoRsM) < Global.Infinity)
                ? procTubo.PvCalculadoRsM / procTubo.PesoUnKgMLiq
                : float.MaxValue;

            return result;
        }

        public static float CapProducaoMH(ProcTubo procTubo)      // BF
        {
            float maximo = procTubo.TuSinterizadoMinM > procTubo.TuTesteEstanqMinM
                ? procTubo.TuSinterizadoMinM
                : procTubo.TuTesteEstanqMinM;

            return Function.Multiplo((float)Math.Floor(60f / maximo), 10);
        }

        public static float PvCalculadoRsM(ProcTubo procTubo)       // BH
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var par = db.Parametros.First();
                result = procTubo.CustoTotalRsM * 0.66f / ((0.66f * (1 - par.Icms - 0.0925f - par.Inss - par.Comissão - par.ComissGestVenda -
                    (par.Frete + par.CustoFin + par.CustoCobranca) * (1f + par.Ipi)) -
                    par.MargemLiquida * (1f - par.Icms - 0.0925f - par.Inss))); 
            }

            return result;
        }
    }
}