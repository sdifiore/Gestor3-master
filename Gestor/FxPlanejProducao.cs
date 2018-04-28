using Gestor.Models;
using System;
using System.Linq;

namespace Gestor
{
    public static class FxPlanejProducao
    {
        public static int UnUArm(PlanejProducao planej)     // G
        {
            int result;
            using (var db = new ApplicationDbContext())
            {
                var produto = db.Produtos.SingleOrDefault(p => p.Id == planej.ProdutoId);
                result = produto == null
                    ? 0
                    : produto.QtUnPorUnArmz; 
            }

            return result;
        }

        public static string TipoPcp(PlanejProducao planej)     // I
        {
            string result = "";
            using (var db = new ApplicationDbContext())
            {
                var produto = db.Produtos.SingleOrDefault(p => p.Id == planej.ProdutoId);
                if (produto != null)
                {
                    int id = produto.TipoProdId;
                    var tipoProd = db.Tipos.SingleOrDefault(t => t.TipoId == id);
                    if (tipoProd != null) result = tipoProd.Descricao;
                } 
            }

            return result;
        }

        public static float Estoque(PlanejProducao planej)        // J
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var cubo = db.CubosEstoque.SingleOrDefault(c => c.Id == planej.ProdutoId);
                result = cubo == null
                    ? 0
                    : cubo.Quantidade; 
            }

            return result;
        }

        public static float EstoqueReposicao(PlanejProducao planej)     // H
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                float soma = planej.VendaMesMenos00 + planej.VendaMesMenos01 + planej.VendaMesMenos02 +
                        planej.VendaMesMenos03 + planej.VendaMesMenos04 + planej.VendaMesMenos05 +
                        planej.VendaMesMenos06 + planej.VendaMesMenos07 + planej.VendaMesMenos08 +
                        planej.VendaMesMenos09 + planej.VendaMesMenos10 + planej.VendaMesMenos11;
                float intermediate = (float)Math.Ceiling(soma / 52f * db.Parametros.First().SemanasReposicao);
                result = intermediate > planej.UnUArm
                    ? intermediate
                    : planej.UnUArm; 
            }

            return result;
        }

        public static float VendaMesMenos11(PlanejProducao planej)      // K
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.CdsmtCfMatAnoMenos3
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos10(PlanejProducao planej)      // L
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.CdsmtCfMatAnoMenos2
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos09(PlanejProducao planej)      // M
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.CdsmtCfMatAno
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos08(PlanejProducao planej)      // N
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos12
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos07(PlanejProducao planej)      // O
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos11
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos06(PlanejProducao planej)      // P
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos10
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos05(PlanejProducao planej)      // Q
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos9
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos04(PlanejProducao planej)      // R
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos8
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos03(PlanejProducao planej)      // S
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos7
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos02(PlanejProducao planej)      // T
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos6
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos01(PlanejProducao planej)      // U
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos5
                    : 0; 
            }

            return result;
        }

        public static float VendaMesMenos00(PlanejProducao planej)      // V
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var planejVenda = db.PlanejVendas.SingleOrDefault(p => p.ProdutoId == planej.ProdutoId);
                result = planejVenda != null
                    ? planejVenda.QtvQtTottAnoMenos4
                    : 0; 
            }

            return result;
        }

        public static float PmpAnoMenos11(PlanejProducao planej)      // W
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos11 - planej.Estoque + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos11(PlanejProducao planej)        // AI
        {
            float result = planej.Estoque - planej.VendaMesMenos11 + planej.PmpAnoMenos11;

            return result;
        }

        public static float PmpAnoMenos10(PlanejProducao planej)      // X
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos10 - planej.SfmAnoMenos11 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos10(PlanejProducao planej)        // AJ
        {
            float result = planej.Estoque - planej.VendaMesMenos10 + planej.PmpAnoMenos10;

            return result;
        }

        public static float PmpAnoMenos09(PlanejProducao planej)      // Y
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos09 - planej.SfmAnoMenos10 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos09(PlanejProducao planej)        // AK
        {
            float result = planej.Estoque - planej.VendaMesMenos09 + planej.PmpAnoMenos09;

            return result;
        }

        public static float PmpAnoMenos08(PlanejProducao planej)      // Z
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos08 - planej.SfmAnoMenos09 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos08(PlanejProducao planej)        // AL
        {
            float result = planej.Estoque - planej.VendaMesMenos08 + planej.PmpAnoMenos08;

            return result;
        }

        public static float PmpAnoMenos07(PlanejProducao planej)      // AA
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos07 - planej.SfmAnoMenos08 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos07(PlanejProducao planej)        // AM
        {
            float result = planej.Estoque - planej.VendaMesMenos07 + planej.PmpAnoMenos07;

            return result;
        }

        public static float PmpAnoMenos06(PlanejProducao planej)      // AB
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos06 - planej.SfmAnoMenos07 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos06(PlanejProducao planej)        // AN
        {
            float result = planej.Estoque - planej.VendaMesMenos06 + planej.PmpAnoMenos06;

            return result;
        }

        public static float PmpAnoMenos05(PlanejProducao planej)      // AC
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos05 - planej.SfmAnoMenos06 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos05(PlanejProducao planej)        // AO
        {
            float result = planej.Estoque - planej.VendaMesMenos05 + planej.PmpAnoMenos05;

            return result;
        }

        public static float PmpAnoMenos04(PlanejProducao planej)      // AD
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos04 - planej.SfmAnoMenos05 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos04(PlanejProducao planej)        // AP
        {
            float result = planej.Estoque - planej.VendaMesMenos04 + planej.PmpAnoMenos04;

            return result;
        }

        public static float PmpAnoMenos03(PlanejProducao planej)      // AE
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos03 - planej.SfmAnoMenos04 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos03(PlanejProducao planej)        // AQ
        {
            float result = planej.Estoque - planej.VendaMesMenos03 + planej.PmpAnoMenos03;

            return result;
        }

        public static float PmpAnoMenos02(PlanejProducao planej)      // AF
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos02 - planej.SfmAnoMenos03 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos02(PlanejProducao planej)        // AR
        {
            float result = planej.Estoque - planej.VendaMesMenos02 + planej.PmpAnoMenos02;

            return result;
        }

        public static float PmpAnoMenos01(PlanejProducao planej)      // AG
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos01 - planej.SfmAnoMenos02 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos01(PlanejProducao planej)        // AS
        {
            float result = planej.Estoque - planej.VendaMesMenos01 + planej.PmpAnoMenos01;

            return result;
        }

        public static float PmpAnoMenos00(PlanejProducao planej)      // AH
        {
            float result = 0;
            float pcp = planej.TipoPcp.ToLower() == "pe"
                ? planej.EstoqueReposicao
                : 0;
            float intermediate = planej.VendaMesMenos00 - planej.SfmAnoMenos01 + pcp;

            if (Math.Abs(intermediate) > Global.Tolerance) result = (float)Math.Ceiling(intermediate);
            else
            {
                result = Math.Abs(planej.UnUArm) > Global.Tolerance
                    ? planej.UnUArm
                    : 1;
            }

            return result;
        }

        public static float SfmAnoMenos00(PlanejProducao planej)        // AT
        {
            float result = planej.Estoque - planej.VendaMesMenos00 + planej.PmpAnoMenos00;

            return result;
        }
    }
}