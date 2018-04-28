using Gestor.Models;
using System;
using System.Linq;

namespace Gestor
{
    public static class FxProduto
    {
        public static float PesoLiquidoCalc(Produto produto)        // R
        {
            float final;
            using (var db = new ApplicationDbContext())
            {
                var comp = XmlReader.Read("SequenciaA");
                var estrutura = db.Estruturas;
                var operando = estrutura.Where(e => e.ProdutoId == produto.Id && e.Sequencia.Tipo == comp);
                final = operando.Any()
                    ? operando.Sum(e => e.PsLiqdFnl) + operando.Sum(e => e.PsLiqdPrcdt)
                    : 0; 
            }

            return final;
        }

        public static int ItemStru(Produto produto)     // S
        {
            int result;
            using (var db = new ApplicationDbContext())
            {
                result = db.Estruturas.Count(e => e.ProdutoId == produto.Id); 
            }

            return result;
        }

        public static float CustoDirTotal(Produto produto)      // T
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                IQueryable<Estrutura> estrutura;

                if (produto.ClasseCusto.Descricao != XmlReader.Read("MercadoriaRevenda"))
                {
                    estrutura = db.Estruturas.Where(e => e.ProdutoId == produto.Id);
                    result = estrutura.Any() ? estrutura.Sum(e => e.CstCmprUndPrd) : 0;
                }

                else
                    result = db.Insumos.Where(i => i.Apelido == produto.Apelido).Sum(i => i.CustoUndCnsm); 
            }

            return result;
        }

        public static float CstMatUltmEtapa(Produto produto)        // U
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var operando = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido);
                result = operando.Any()
                    ? operando.Sum(e => e.CstMtrlDrt)
                    : 0; 
            }

            return result;
        }

        public static float CstMatEtapa1(Produto produto)        // V
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var operando = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido);
                result = operando.Any()
                    ? operando.Sum(e => e.CstMtrlPrcd1)
                    : 0; 
            }

            return result;
        }

        public static float CstMatEtapa2(Produto produto)        // W
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var operando = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido);
                result = operando.Any()
                    ? operando.Sum(e => e.CstMtrlPrcd2)
                    : 0; 
            }

            return result;
        }

        public static float CstMatEtapa3(Produto produto)        // X
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var operando = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido);
                result = operando.Any()
                    ? operando.Sum(e => e.CstMtrlPrcd3)
                    : 0; 
            }

            return result;
        }

        public static float CstTotMaterial(Produto produto)     // Y
        {
            return produto.CstMatUltmEtapa + produto.CstMatEtapa1 + produto.CstMatEtapa2 + produto.CstMatEtapa3;
        }

        public static float CustoDirMod(Produto produto)        // Z
        {
            float result = produto.ClasseCusto.Descricao != XmlReader.Read("MercadoriaRevenda")
                ? produto.CustODirTotal - produto.CstTotMaterial
                : 0;

            return result;
        }

        public static float HorasModUltmEtapa(Produto produto)      // AA
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var comp1 = XmlReader.Read("SequenciaE1");
                var comp2 = XmlReader.Read("SequenciaE2");
                var estrutura = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido && e.Sequencia.Tipo == comp1);
                float a = estrutura.Any() ? estrutura.Sum(e => e.HrsModFnl) : 0;
                estrutura = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido && e.Sequencia.Tipo == comp2);
                float b = estrutura.Any() ? estrutura.Sum(e => e.HrsModFnl) : 0;
                result = a + b; 
            }

            return result;
        }

        public static float HorasModEtapa1(Produto produto)     // AB
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var operando = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido);
                result = operando.Any()
                    ? operando.Sum(e => e.HrsModPrec1)
                    : 0; 
            }

            return result;
        }

        public static float HorasModEtapa2(Produto produto)     // AC
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var operando = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido);
                result = operando.Any()
                    ? operando.Sum(e => e.HrsModPrec2)
                    : 0; 
            }

            return result;
        }

        public static float HorasModTotal(Produto produto)      // AD
        {
            float result = produto.HorasModUltmEtapa + produto.HorasModEtapa1 + produto.HorasModEtapa2;

            return result;
        }

        public static float CapProdHora(Produto produto)        // AE
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var comp = XmlReader.Read("SequenciaE1");
                var operando = db.Estruturas.Where(e => e.Produto.Apelido == produto.Apelido && e.Sequencia.Tipo == comp);
                result = operando.Any()
                    ? operando.Sum(e => e.PdrHoraria)
                    : 0; 
            }

            return result;
        }

        public static int LoteMinimo(Produto produto)     // AF
        {
            int result = 0;
            using (var db = new ApplicationDbContext())
            {
                string grupoDeRateio = db.GruposRateio.Single(gr => gr.GrupoRateioId == produto.GrupoRateioId).Descricao;
                var rateio = db.Rateios.SingleOrDefault(r => r.Grupo.ToLower() == grupoDeRateio.ToLower());

                if (rateio != null)
                {
                    float temp = (float)Math.Ceiling(rateio.Horas * produto.CapProdHora);
                    if (Math.Abs(produto.QtUnPorUnArmz) < Global.Tolerance) temp = 0;
                    result = temp > produto.QtUnPorUnArmz ? (int)temp : produto.QtUnPorUnArmz;
                } 
            }

            return result;
        }

        public static int UsoStru(Produto produto)      // AG
        {
            int result;
            using (var db = new ApplicationDbContext())
            {
                result = db.Estruturas.Count(e => e.Item == produto.Apelido);
            }

            return result;
        }

        public static int CustoDir(Produto produto)     // AH
        {
            int result = Math.Abs(produto.PesoLiquidoCalc) > Global.Tolerance
                ? (int)Math.Round(produto.CustODirTotal / produto.PesoLiquidoCalc)
                : 0;

            return result;
        }

        public static float RelModCstDir(Produto produto)     // AI
        {
            float result = Math.Abs(produto.CustODirTotal) > Global.Tolerance
                ? produto.CustoDirMod / produto.CustODirTotal
                : 0;

            return result;
        }

        public static float PctMatEtapaFinal(Produto produto)     // AJ
        {
            float result = Math.Abs(produto.CstTotMaterial) > Global.Tolerance
                ? produto.CstMatUltmEtapa / produto.CstTotMaterial
                : 0;

            return result;
        }

        public static float PctMatEtapa1(Produto produto)     // AK
        {
            float result = Math.Abs(produto.CstTotMaterial) > Global.Tolerance
                ? produto.CstMatEtapa1 / produto.CstTotMaterial
                : 0;

            return result;
        }

        public static float PctMatEtapa2(Produto produto)     // AL
        {
            float result = Math.Abs(produto.CstTotMaterial) > Global.Tolerance
                ? produto.CstMatEtapa2 / produto.CstTotMaterial
                : 0;

            return result;
        }

        public static float PctMatEtapa3(Produto produto)     // AM
        {
            float result = Math.Abs(produto.CstTotMaterial) > Global.Tolerance
                ? produto.CstMatEtapa3/ produto.CstTotMaterial
                : 0;

            return result;
        }

        public static string DescricaoUnidade(Produto produto)     // AN
        {
            string result;
            using (var db = new ApplicationDbContext())
            {
                int id = produto.UnidadeId;
                string unidade = db.Unidades.Find(id).Descricao;
                result = $"{produto.Descricao} | {unidade}"; 
            }
            return result;
        }

        public static float CustoFixoTotal(Produto produto)     // S Planilha 2
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                float intermediate = 1;
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;
                if (produto.GrupoRateioId == id) intermediate = produto.QtdUnid;
                var grupo = db.IndiceRateioFormacaoPrecoVendas.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                if (grupo != null) result = intermediate * produto.HorasModTotal * grupo.TotalCustoFixo; 
            }

            return result;
        }

        public static float MoiFabricacao(Produto produto)     // Planilha 2, T
        {
            float result = 0;

            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.MoiFabrica;
                }

                else
                {
                    var grupo = db.IndiceRateioFormacaoPrecoVendas.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * grupo.MoiFabricacao;
                } 
            }

            return result;
        }

        public static float OutrosCustosFab(Produto produto)        // U
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.DespsFabrica;
                }

                else
                {
                    var grupo = db.IndiceRateioFormacaoPrecoVendas.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * grupo.OutroCustoFixoFabricacao;
                } 
            }

            return result;
        }

        public static float ComacsComtexFpv(Produto produto)        // V
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.DespsDepComercial;
                }

                else
                {
                    var grupo = db.IndiceRateioFormacaoPrecoVendas.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * (grupo.CustoFixoComacs + grupo.CustoFixoComtex);
                } 
            }

            return result;
        }

        public static float CustoFixoAdminLogFpv(Produto produto)       // W
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.DespsDeptAdminLog;
                }

                else
                {
                    var grupo = db.IndiceRateioFormacaoPrecoVendas.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * grupo.CustoFixoAdminLog;
                } 
            }

            return result;
        }

        public static float RsMoiDespFabHMod(Produto produto)       // X
        {
            float result = Math.Abs(produto.HorasModTotal) > Global.Tolerance
                ? (produto.MoiFabricacao + produto.OutrosCustosFab) / produto.HorasModTotal
                : 0;

            return result;
        }

        public static float RsSgNAHMod(Produto produto)       // Y
        {
            float result = Math.Abs(produto.HorasModTotal) > Global.Tolerance
                ? (produto.ComacsComtexFpv + produto.CustoFixoAdminLogFpv) / produto.HorasModTotal
                : 0;

            return result;
        }

        public static float CustoFixoTotalAnr(Produto produto)       // Z
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                float intermediate = 1;
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;
                if (produto.GrupoRateioId == id) intermediate = produto.QtdUnid;
                var grupo = db.IndiceRateioLucratividades.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                if (grupo != null) result = intermediate * produto.HorasModTotal * grupo.TotalCustoFixo; 
            }

            return result;
        }

        public static float MoiFabricAnr(Produto produto)       // AA
        {

            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var boh = produto.Apelido;
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.MoiFabrica;
                }

                else
                {
                    var grupo = db.IndiceRateioLucratividades.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * grupo.MoiFabricacao;
                } 
            }

            return result;
        }

        public static float OutrosCustosFabricAnr(Produto produto)       // AB
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var boh = produto.Apelido;
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.DespsFabrica;
                }

                else
                {
                    var grupo = db.IndiceRateioLucratividades.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * grupo.OutroCustoFixoFabricacao;
                } 
            }

            return result;
        }

        public static float CustoFixoComacsCmtexAnr(Produto produto)       // AC
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var boh = produto.Apelido;
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.DespsDepComercial;
                }

                else
                {
                    var grupo = db.IndiceRateioLucratividades.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * (grupo.CustoFixoComacs + grupo.CustoFixoComtex);
                } 
            }

            return result;
        }
        public static float CustoFixoAdminAnr(Produto produto)       // AD
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var boh = produto.Apelido;
                string comp = XmlReader.Read("GrupoRateioRevenda");
                int id = db.Rateios.Single(g => g.Grupo == comp).RateioId;

                if (produto.GrupoRateioId == id)
                {
                    var rateio = db.DfxProdRevs.SingleOrDefault(d => d.Produto.Apelido == produto.Apelido);
                    if (rateio != null) result = rateio.DespsDeptAdminLog;
                }

                else
                {
                    var grupo = db.IndiceRateioLucratividades.SingleOrDefault(i => i.GrupoRateioId == produto.GrupoRateioId);
                    if (grupo != null) result = produto.HorasModTotal * grupo.CustoFixoAdminLog;
                } 
            }

            return result;
        }

        public static float PropCustoFixoTotal(Produto produto)     // Planilha 4, T
        {
            float intermediate = produto.CustODirTotal + produto.CustoFixoTotal;
            float result = Math.Abs(intermediate) > Global.Tolerance
                ? produto.CustoFixoTotal / intermediate
                : 0;

            return result;
        }

        public static float CstDirUnidade(Produto produto)     // Planilha 4, T
        {
            float result = Math.Abs(produto.QtdUnid) > Global.Tolerance
                ? produto.CstDirUnidade / produto.QtdUnid
                : 0;

            return result;
        }

        public static float CstIndirUnidade(Produto produto)     // Planilha 4, T
        {
            float result = Math.Abs(produto.QtdUnid) > Global.Tolerance
                ? produto.CustoFixoTotal / produto.QtdUnid
                : 0;

            return result;
        }
    }
}