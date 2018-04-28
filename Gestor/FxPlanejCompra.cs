using Gestor.Models;
using System;
using System.Linq;

namespace Gestor
{
    public static class FxPlanejCompra
    {
        public static float FatorConsumo(PlanejCompra planej)       // R
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.QtdUnddConsumo;
                } 
            }

            return result;
        }

        public static float LoteCompra(PlanejCompra planej)       // S
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.QtdMltplCompra;
                } 
            }

            return result;
        }

        public static float EstoqueMinimo(PlanejCompra planej)      // T
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string ptfe = XmlReader.Read("SemanaEstoquePtfe");
                string demais = XmlReader.Read("SemanaEstoqueDemais");
                int insumoId = planej.InsumoId;
                var insumo = db.Insumos.Single(i => i.InsumoId == insumoId);
                int categoriaId = insumo.CategoriaId;
                var categoria = db.Categorias.Single(ct => ct.CategoriaId == categoriaId);

                float a = categoria.Apelido == "50"
                    ? db.SemanasEstoque.Single(S => S.Apelido == ptfe).Semanas
                    : db.SemanasEstoque.Single(S => S.Apelido == demais).Semanas;

                float b = planej.SomaDe1 + planej.SomaDe2 + planej.SomaDe3 + planej.SomaDe4 + planej.SomaDe5 + planej.SomaDe6 +
                    planej.SomaDe7 + planej.SomaDe8 + planej.SomaDe9 + planej.SomaDe10 + planej.SomaDe11 + planej.SomaDe12;

                int c = 0;
                if (Math.Abs(planej.SomaDe1) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe2) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe3) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe4) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe5) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe6) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe7) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe8) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe9) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe10) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe11) > Global.Tolerance) c++;
                if (Math.Abs(planej.SomaDe12) > Global.Tolerance) c++;

                float d = c > 3 ? 1 : 0;

                result = a / 4 * b / 12 * planej.FatorConsumo * d; 
            }

            return result;
        }

        public static float PrecoUnitarioBruto(PlanejCompra planej)        // U
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.PrcBrtCompra;
                } 
            }

            return result;
        }

        public static float CustoUnitario(PlanejCompra planej)        // V
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.Custo;
                } 
            }

            return result;
        }

        public static float CreditoUnitIcms(PlanejCompra planej)        // W
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.CrdtIcms; // O valor CrdtICMS é ASSUMIDO, uma vez que a fórmula repetia o cálculo anterior indicando erro.
                } 
            }

            return result;
        }

        public static float CreditoUnitIpi(PlanejCompra planej)        // X
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.CrdtIpi;
                } 
            }

            return result;
        }

        public static float CreditoUnitPis(PlanejCompra planej)        // Y
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.CrdtPis;
                } 
            }

            return result;
        }

        public static float CreditoUnitCofins(PlanejCompra planej)        // Z
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.CrdtCofins;
                } 
            }

            return result;
        }

        public static float PagFornecImport(PlanejCompra planej)        // AA
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.PgtFornecImp;
                } 
            }

            return result;
        }

        public static float IiDespImport(PlanejCompra planej)        // AB
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.DspImportacao;
                } 
            }

            return result;
        }

        public static int MesRefPag1Fornec(PlanejCompra planej)       // AC
        {
            int result;
            using (var db = new ApplicationDbContext())
            {
                var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                float intermediate = insumo != null
                    ? insumo.Prazo1 / 30f
                    : 0;
                result = (int)Math.Round(intermediate, 0); 
            }

            return result;
        }

        public static int MesRefPag2Fornec(PlanejCompra planej)       // AD
        {
            int result;
            using (var db = new ApplicationDbContext())
            {
                var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                float intermediate = insumo != null
                    ? insumo.Prazo2 / 30f
                    : 0;
                result = (int)Math.Round(intermediate, 0); 
            }

            return result;
        }

        public static float PctPag1(PlanejCompra planej)       // AE
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                    if (insumo != null) result = insumo.PctPgto1;
                } 
            }

            return result;
        }

        public static float EstoqueInicial(PlanejCompra planej)     // AF
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var insumo = db.Insumos.SingleOrDefault(i => i.InsumoId == planej.InsumoId);
                if (insumo == null) DbLogger.Log(Reason.Error, $"Insumo id {planej.InsumoId} não encontrado em PlanejCompra EstoqueInicial");
                else
                {
                    var estoque = db.CubosEstoque.SingleOrDefault(e => e.Apelido == insumo.Apelido);
                    if (estoque != null) result = estoque.Quantidade;
                } 
            }

            return result;
        }

        public static float NCMPAnoMenos11(PlanejCompra planej)     // AG
        {
            return planej.SomaDe1 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos10(PlanejCompra planej)     // AH
        {
            return planej.SomaDe2 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos9(PlanejCompra planej)     // AI
        {
            return planej.SomaDe3 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos8(PlanejCompra planej)     // AJ
        {
            return planej.SomaDe4 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos7(PlanejCompra planej)     // AK
        {
            return planej.SomaDe5 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos6(PlanejCompra planej)     // AL
        {
            return planej.SomaDe6 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos5(PlanejCompra planej)     // AM
        {
            return planej.SomaDe7 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos4(PlanejCompra planej)     // AN
        {
            return planej.SomaDe8 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos3(PlanejCompra planej)     // AO
        {
            return planej.SomaDe9 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos2(PlanejCompra planej)     // AP
        {
            return planej.SomaDe10 * planej.FatorConsumo;
        }

        public static float NCMPAnoMenos1(PlanejCompra planej)     // AQ
        {
            return planej.SomaDe11 * planej.FatorConsumo;
        }

        public static float NCMPAno(PlanejCompra planej)     // AR
        {
            return planej.SomaDe12 * planej.FatorConsumo;
        }

        public static float QCMes1(PlanejCompra planej)     // AS
        {
            float result = 0;
            float a = planej.NCMPAnoMenos11 - planej.EstoqueInicial + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes2(PlanejCompra planej)     // AT
        {
            float result = 0;
            float a = planej.NCMPAnoMenos10 - planej.SFCMAnoMenos11 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes3(PlanejCompra planej)     // AU
        {
            float result = 0;
            float a = planej.NCMPAnoMenos9 - planej.SFCMAnoMenos10 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes4(PlanejCompra planej)     // AV
        {
            float result = 0;
            float a = planej.NCMPAnoMenos8 - planej.SFCMAnoMenos9 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes5(PlanejCompra planej)     // AW
        {
            float result = 0;
            float a = planej.NCMPAnoMenos7 - planej.SFCMAnoMenos8 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes6(PlanejCompra planej)     // AX
        {
            float result = 0;
            float a = planej.NCMPAnoMenos6 - planej.SFCMAnoMenos7 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes7(PlanejCompra planej)     // AY
        {
            float result = 0;
            float a = planej.NCMPAnoMenos5 - planej.SFCMAnoMenos6 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes8(PlanejCompra planej)     // AZ
        {
            float result = 0;
            float a = planej.NCMPAnoMenos4 - planej.SFCMAnoMenos5 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes9(PlanejCompra planej)     // BA
        {
            float result = 0;
            float a = planej.NCMPAnoMenos3 - planej.SFCMAnoMenos4 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes10(PlanejCompra planej)     // BB
        {
            float result = 0;
            float a = planej.NCMPAnoMenos2 - planej.SFCMAnoMenos3 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes11(PlanejCompra planej)     // BC
        {
            float result = 0;
            float a = planej.NCMPAnoMenos1 - planej.SFCMAnoMenos2 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float QCMes12(PlanejCompra planej)     // BD
        {
            float result = 0;
            float a = planej.NCMPAno - planej.SFCMAnoMenos1 + planej.EstoqueMinimo;
            if (a > Global.Tolerance)
            {
                result = Function.MinCeiling(a, planej.LoteCompra);
            }

            return result;
        }

        public static float TotalPeriodo(PlanejCompra planej)       // BE
        {
            float result = planej.QCMes1 + planej.QCMes2 + planej.QCMes3 + planej.QCMes4 + planej.QCMes5 + planej.QCMes6 +
                planej.QCMes7 + planej.QCMes8 + planej.QCMes9 + planej.QCMes10 + planej.QCMes11 + planej.QCMes12;

            return result;
        }

        public static float SFCMAnoMenos11(PlanejCompra planej)     // BF
        {
            float result = planej.EstoqueInicial - planej.NCMPAnoMenos11 + planej.QCMes1;

            return result;
        }

        public static float SFCMAnoMenos10(PlanejCompra planej)     // BG
        {
            float result = planej.SFCMAnoMenos11 - planej.NCMPAnoMenos10 + planej.QCMes2;

            return result;
        }

        public static float SFCMAnoMenos9(PlanejCompra planej)     // BH
        {
            float result = planej.SFCMAnoMenos10 - planej.NCMPAnoMenos9 + planej.QCMes3;

            return result;
        }

        public static float SFCMAnoMenos8(PlanejCompra planej)     // BI
        {
            float result = planej.SFCMAnoMenos9 - planej.NCMPAnoMenos8 + planej.QCMes4;

            return result;
        }

        public static float SFCMAnoMenos7(PlanejCompra planej)     // BJ
        {
            float result = planej.SFCMAnoMenos8 - planej.NCMPAnoMenos7 + planej.QCMes5;

            return result;
        }

        public static float SFCMAnoMenos6(PlanejCompra planej)     // BK
        {
            float result = planej.SFCMAnoMenos7 - planej.NCMPAnoMenos6 + planej.QCMes6;

            return result;
        }

        public static float SFCMAnoMenos5(PlanejCompra planej)     // BL
        {
            float result = planej.SFCMAnoMenos6 - planej.NCMPAnoMenos5 + planej.QCMes7;

            return result;
        }

        public static float SFCMAnoMenos4(PlanejCompra planej)     // BM
        {
            float result = planej.SFCMAnoMenos5 - planej.NCMPAnoMenos4 + planej.QCMes8;

            return result;
        }

        public static float SFCMAnoMenos3(PlanejCompra planej)     // BN
        {
            float result = planej.SFCMAnoMenos4 - planej.NCMPAnoMenos3 + planej.QCMes9;

            return result;
        }

        public static float SFCMAnoMenos2(PlanejCompra planej)     // BO
        {
            float result = planej.SFCMAnoMenos3 - planej.NCMPAnoMenos2 + planej.QCMes10;

            return result;
        }

        public static float SFCMAnoMenos1(PlanejCompra planej)     // BP
        {
            float result = planej.SFCMAnoMenos2 - planej.NCMPAnoMenos1 + planej.QCMes11;

            return result;
        }

        public static float SFCMAno(PlanejCompra planej)     // BQ
        {
            float result = planej.SFCMAnoMenos1 - planej.NCMPAno + planej.QCMes12;

            return result;
        }

        public static float VBCMes1(PlanejCompra planej)     // BR
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes1 : 0; 
            }

            return result;
        }

        public static float VBCMes2(PlanejCompra planej)     // BS
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes2 : 0; 
            }

            return result;
        }

        public static float VBCMes3(PlanejCompra planej)     // BT
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes3 : 0; 
            }

            return result;
        }

        public static float VBCMes4(PlanejCompra planej)     // BU
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes4 : 0; 
            }

            return result;
        }

        public static float VBCMes5(PlanejCompra planej)     // BV
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes5 : 0; 
            }

            return result;
        }

        public static float VBCMes6(PlanejCompra planej)     // BW
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes6 : 0;

            }
            return result;
        }

        public static float VBCMes7(PlanejCompra planej)     // BX
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes7 : 0; 
            }

            return result;
        }

        public static float VBCMes8(PlanejCompra planej)     // BY
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes8 : 0; 
            }

            return result;
        }

        public static float VBCMes9(PlanejCompra planej)     // BZ
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes9 : 0; 
            }

            return result;
        }

        public static float VBCMes10(PlanejCompra planej)     // CA
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes10 : 0; 
            }

            return result;
        }

        public static float VBCMes11(PlanejCompra planej)     // CB
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes11 : 0; 
            }

            return result;
        }

        public static float VBCMes12(PlanejCompra planej)     // CC
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id ? planej.PrecoUnitarioBruto * planej.QCMes12 : 0; 
            }

            return result;
        }

        public static float PFNMesN(PlanejCompra planej, int indice)        // CD -> CO
        {
            float a = 0;
            float b = 0;
            string comp = XmlReader.Read("InsumoNaoExistente");
            using (var db = new ApplicationDbContext())
            {
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    float[] vcb = new float[]
                    {
                    planej.VBCMes1,
                    planej.VBCMes2,
                    planej.VBCMes3,
                    planej.VBCMes4,
                    planej.VBCMes5,
                    planej.VBCMes6,
                    planej.VBCMes7,
                    planej.VBCMes8,
                    planej.VBCMes9,
                    planej.VBCMes10,
                    planej.VBCMes11,
                    planej.VBCMes12
                    };

                    int i = indice - planej.MesRefPag1Fornec;
                    int j = indice - planej.MesRefPag2Fornec;
                    if (i > 11) i = 11;
                    if (j > 11) j = 11;
                    if (i > -1) a = vcb[i] * planej.PctPag1;
                    if (j > -1) b = vcb[j] * (1 - planej.PctPag1);
                } 
            }

            return a + b;
        }

        public static float PFIMes1(PlanejCompra planej, int indice)        // CP
        {
            float a = 0;
            float b = 0;
            string comp = XmlReader.Read("InsumoNaoExistente");
            using (var db = new ApplicationDbContext())
            {
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                if (planej.InsumoId != id)
                {
                    float[] vcb = new float[]
                    {
                    planej.QCMes1,
                    planej.QCMes2,
                    planej.QCMes3,
                    planej.QCMes4,
                    planej.QCMes5,
                    planej.QCMes6,
                    planej.QCMes7,
                    planej.QCMes8,
                    planej.QCMes9,
                    planej.QCMes10,
                    planej.QCMes11,
                    planej.QCMes12
                    };

                    int i = indice - planej.MesRefPag1Fornec;
                    int j = indice - planej.MesRefPag2Fornec;
                    if (i > 11) i = 11;
                    if (j > 11) j = 11;
                    if (i > -1) a = vcb[i] * planej.PagFornecImport * planej.PctPag1;
                    if (j > -1) b = vcb[j] * planej.PagFornecImport * (1 - planej.PctPag1);
                } 
            }

            return a + b;
        }

        public static float PIIDIMes1(PlanejCompra planej)        // DB
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes1
                : 0;

            return result;
        }

        public static float PIIDIMes2(PlanejCompra planej)        // DC
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes2
                : 0;

            return result;
        }

        public static float PIIDIMes3(PlanejCompra planej)        // DD
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes3
                : 0;

            return result;
        }

        public static float PIIDIMes4(PlanejCompra planej)        // DE
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes4
                : 0;

            return result;
        }

        public static float PIIDIMes5(PlanejCompra planej)        // DF
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes5
                : 0;

            return result;
        }

        public static float PIIDIMes6(PlanejCompra planej)        // DG
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes6
                : 0;

            return result;
        }

        public static float PIIDIMes7(PlanejCompra planej)        // DH
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes7
                : 0;

            return result;
        }

        public static float PIIDIMes8(PlanejCompra planej)        // DI
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes8
                : 0;

            return result;
        }

        public static float PIIDIMes9(PlanejCompra planej)        // DJ
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes9
                : 0;

            return result;
        }

        public static float PIIDIMes10(PlanejCompra planej)        // DK
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes10
                : 0;

            return result;
        }

        public static float PIIDIMes11(PlanejCompra planej)        // DL
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes11
                : 0;

            return result;
        }

        public static float PIIDIMes12(PlanejCompra planej)        // DM
        {
            float result = Math.Abs(planej.IiDespImport) > Global.Tolerance
                ? planej.IiDespImport * planej.QCMes12
                : 0;

            return result;
        }

        public static float VCCMes1(PlanejCompra planej)        // DN
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes1
                    : 0; 
            }

            return result;
        }

        public static float VCCMes2(PlanejCompra planej)        // DO
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes2
                    : 0; 
            }

            return result;
        }

        public static float VCCMes3(PlanejCompra planej)        // DP
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes3
                    : 0; 
            }

            return result;
        }

        public static float VCCMes4(PlanejCompra planej)        // DQ
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;

                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes4
                    : 0;

            }
            return result;
        }

        public static float VCCMes5(PlanejCompra planej)        // DR
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes5
                    : 0; 
            }

            return result;
        }

        public static float VCCMes6(PlanejCompra planej)        // DS
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes6
                    : 0; 
            }

            return result;
        }

        public static float VCCMes7(PlanejCompra planej)        // DT
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes7
                    : 0; 
            }

            return result;
        }

        public static float VCCMes8(PlanejCompra planej)        // DU
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes8
                    : 0; 
            }

            return result;
        }

        public static float VCCMes9(PlanejCompra planej)        // DV
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes9
                    : 0; 
            }

            return result;
        }

        public static float VCCMes10(PlanejCompra planej)        // DW
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes10
                    : 0; 
            }

            return result;
        }

        public static float VCCMes11(PlanejCompra planej)        // DX
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes11
                    : 0; 
            }

            return result;
        }

        public static float VCCMes12(PlanejCompra planej)        // DY
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CustoUnitario * planej.QCMes12
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes1(PlanejCompra planej)        // DZ
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes1
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes2(PlanejCompra planej)        // EA
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes2
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes3(PlanejCompra planej)        // EB
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes3
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes4(PlanejCompra planej)        // EC
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes4
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes5(PlanejCompra planej)        // ED
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes5
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes6(PlanejCompra planej)        // EE
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes6
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes7(PlanejCompra planej)        // EF
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes7
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes8(PlanejCompra planej)        // EG
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes8
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes9(PlanejCompra planej)        // EH
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes9
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes10(PlanejCompra planej)        // EI
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes10
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes11(PlanejCompra planej)        // EJ
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes11
                    : 0; 
            }

            return result;
        }

        public static float VCIcmsMes12(PlanejCompra planej)        // EK
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIcms * planej.QCMes12
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes1(PlanejCompra planej)        // EL
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes1
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes2(PlanejCompra planej)        // EM
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes2
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes3(PlanejCompra planej)        // EN
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes3
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes4(PlanejCompra planej)        // EO
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes4
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes5(PlanejCompra planej)        // EP
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes5
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes6(PlanejCompra planej)        // EQ
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes6
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes7(PlanejCompra planej)        // ER
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes7
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes8(PlanejCompra planej)        // ES
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes8
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes9(PlanejCompra planej)        // ET
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes9
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes10(PlanejCompra planej)        // EU
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes10
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes11(PlanejCompra planej)        // EV
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes11
                    : 0; 
            }

            return result;
        }

        public static float VCIpiMes12(PlanejCompra planej)        // EW
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? planej.CreditoUnitIpi * planej.QCMes12
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes1(PlanejCompra planej)        // EX
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes1
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes2(PlanejCompra planej)        // EY
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes2
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes3(PlanejCompra planej)        // EZ
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes3
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes4(PlanejCompra planej)        // FA
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes4
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes5(PlanejCompra planej)        // FB
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes5
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes6(PlanejCompra planej)        // FC
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes6
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes7(PlanejCompra planej)        // FD
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes7
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes8(PlanejCompra planej)        // FE
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes8
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes9(PlanejCompra planej)        // FF
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes9
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes10(PlanejCompra planej)        // FG
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes10
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes11(PlanejCompra planej)        // FH
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes11
                    : 0; 
            }

            return result;
        }

        public static float CPisCofinsMes12(PlanejCompra planej)        // FI
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string comp = XmlReader.Read("InsumoNaoExistente");
                int id = db.Insumos.Single(i => i.Apelido == comp).InsumoId;
                result = planej.InsumoId != id
                    ? (planej.CreditoUnitPis + planej.CreditoUnitCofins) * planej.QCMes12
                    : 0; 
            }

            return result;
        }

        public static float MediaMensal(PlanejCompra planej)        // FJ
        {
            float result = (planej.NCMPAnoMenos11 + planej.NCMPAnoMenos10 + planej.NCMPAnoMenos9 + 
                planej.NCMPAnoMenos8 + planej.NCMPAnoMenos7 + planej.NCMPAnoMenos6 + planej.NCMPAnoMenos5 + 
                planej.NCMPAnoMenos4 + planej.NCMPAnoMenos3 + planej.NCMPAnoMenos2 + planej.NCMPAnoMenos1 + planej.NCMPAno) / 12;

            return result;
        }
    }
}