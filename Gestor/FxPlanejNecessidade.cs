using Gestor.Models;
using System;
using System.Linq;

namespace Gestor
{
    public static class FxPlanejNecessidade
    {
        public static string SetorProducao(Estrutura stru)     // T
        {
            string result = "";

            if (stru.TpItmCst != null)
            {
                string comp = $"{stru.TpItmCst}{Global.Space5}".Substring(0, 5);

                if (comp == "c-MOD")
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var operacao = db.Operacoes.SingleOrDefault(o => o.CodigoOperacao == stru.Item);
                        if (operacao != null) result = operacao.SetorProducao; 
                    }
                } 
            }

            return result;
        }

        public static string Categoria(Estrutura stru)      // U
        {
            string result = "";
            using (var db = new ApplicationDbContext())
            {
                if (stru.TpItmCst == XmlReader.Read("Manufaturado"))
                {
                    var produto = db.Produtos.SingleOrDefault(p => p.Apelido == stru.Item);
                    if (produto != null)
                    {
                        int id = produto.CategoriaId;
                        var categoria = db.Categorias.SingleOrDefault(c => c.CategoriaId == id);
                        if (categoria != null) result = categoria.Descricao;
                    }
                }

                else
                {
                    if (stru.TpItmCst == XmlReader.Read("Insumos"))
                    {
                        var insumo = db.Insumos.SingleOrDefault(i => i.Apelido == stru.Item);
                        if (insumo != null)
                        {
                            int id = insumo.CategoriaId;
                            var categoria = db.Categorias.SingleOrDefault(c => c.CategoriaId == id);
                            if (categoria != null) result = categoria.Descricao;
                        }
                    }
                } 
            }

            return result;
        }

        public static float ListaPlanejProducao(Estrutura stru)     // W
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var pmp = db.PlanejProducoes.SingleOrDefault(p => p.ProdutoId == stru.ProdutoId);
                if (pmp != null) result = pmp.PmpAnoMenos00; 
            }

            return result;
        }

        public static float NeedComponProducao(Estrutura stru)     // X
        {
            float result = 0;

            if ((Math.Abs(stru.ListaPlanejProducao) > Global.Tolerance) && (Math.Abs(stru.QtEftvUntrCmpnt) > Global.Tolerance))
            {
                using (var db = new ApplicationDbContext())
                {
                    string tipo = db.Sequencias.Single(s => s.SequenciaId == stru.SequenciaId).Tipo.Substring(0, 1).ToLower();
                    float intermediate = tipo == "e"
                        ? stru.TempMaq
                        : stru.QtEftvUntrCmpnt;
                    result = stru.ListaPlanejProducao * intermediate; 
                }
            }

            return result;
        }

        public static float ListaNecessProdNivel1(Estrutura stru)     // Y
        {
            float result = 0;

            if (stru.Produto.Apelido != stru.Item)
            {
                using (var db = new ApplicationDbContext())
                {
                    var model = db.Estruturas.Where(e => e.Item == stru.Produto.Apelido).ToList();
                    if (model != null) result = model.Sum(m => m.ListaPlanejProducao); 
                }
            }

            return result;
        }

        public static float NecCompListaP1(Estrutura stru)     // Z
        {
            float result = 0;

            if ((Math.Abs(stru.ListaNecessProdNivel1) > Global.Tolerance) && (Math.Abs(stru.QtEftvUntrCmpnt) > Global.Tolerance))
            {
                using (var db = new ApplicationDbContext())
                {
                    string tipo = db.Sequencias.Single(s => s.SequenciaId == stru.SequenciaId).Tipo.Substring(0, 1).ToLower();
                    float intermediate = tipo == "e"
                       ? stru.TempMaq
                       : stru.QtEftvUntrCmpnt;
                    result = stru.ListaNecessProdNivel1 * intermediate; 
                }
            }

            return result;
        }

        public static float ListaNecessProdNivel2(Estrutura stru)     // AA
        {
            float result = 0;

            if (stru.Produto.Apelido != stru.Item)
            {
                using (var db = new ApplicationDbContext())
                {
                    var model = db.Estruturas.Where(e => e.Item == stru.Produto.Apelido).ToList();
                    if (model != null) result = model.Sum(m => m.NecCompListaP1); 
                }
            }

            return result;
        }

        public static float NecCompListaP2(Estrutura stru)     // AB
        {
            float result = 0;

            if ((Math.Abs(stru.ListaNecessProdNivel2) > Global.Tolerance) && (Math.Abs(stru.QtEftvUntrCmpnt) > Global.Tolerance))
            {
                using (var db = new ApplicationDbContext())
                {
                    string tipo = db.Sequencias.Single(s => s.SequenciaId == stru.SequenciaId).Tipo.Substring(0, 1).ToLower();
                    float intermediate = tipo == "e"
                       ? stru.TempMaq
                       : stru.QtEftvUntrCmpnt;
                    result = stru.ListaNecessProdNivel2 * intermediate; 
                }
            }

            return result;
        }

        public static float ListaNecessProdNivel3(Estrutura stru)     // AC
        {
            float result = 0;

            if (stru.Produto.Apelido != stru.Item)
            {
                using (var db = new ApplicationDbContext())
                {
                    var model = db.Estruturas.Where(e => e.Item == stru.Produto.Apelido).ToList();
                    if (model != null) result = model.Sum(m => m.NecCompListaP2); 
                }
            }

            return result;
        }

        public static float NecCompListaP3(Estrutura stru)     // AD
        {
            float result = 0;

            if ((Math.Abs(stru.ListaNecessProdNivel3) > Global.Tolerance) && (Math.Abs(stru.QtEftvUntrCmpnt) > Global.Tolerance))
            {
                using (var db = new ApplicationDbContext())
                {
                    string tipo = db.Sequencias.Single(s => s.SequenciaId == stru.SequenciaId).Tipo.Substring(0, 1).ToLower();
                    float intermediate = tipo == "e"
                       ? stru.TempMaq
                       : stru.QtEftvUntrCmpnt;
                    result = stru.ListaNecessProdNivel3 * intermediate; 
                }
            }

            return result;
        }

        public static float ListaNecessProdNivel4(Estrutura stru)     // AE
        {
            float result = 0;

            if (stru.Produto.Apelido != stru.Item)
            {
                using (var db = new ApplicationDbContext())
                {
                    var model = db.Estruturas.Where(e => e.Item == stru.Produto.Apelido).ToList();
                    if (model != null) result = model.Sum(m => m.NecCompListaP3); 
                }
            }

            return result;
        }

        public static float NecCompListaP4(Estrutura stru)     // AF
        {
            float result = 0;

            if ((Math.Abs(stru.ListaNecessProdNivel4) > Global.Tolerance) && (Math.Abs(stru.QtEftvUntrCmpnt) > Global.Tolerance))
            {
                using (var db = new ApplicationDbContext())
                {
                    string tipo = db.Sequencias.Single(s => s.SequenciaId == stru.SequenciaId).Tipo.Substring(0, 1).ToLower();
                    float intermediate = tipo == "e"
                       ? stru.TempMaq
                       : stru.QtEftvUntrCmpnt;
                    result = stru.ListaNecessProdNivel4 * intermediate; 
                }
            }

            return result;
        }

        public static float NecTotalComponente(Estrutura stru)     // AG
        {
            float result = stru.NeedComponProducao + stru.NecCompListaP1 + stru.NecCompListaP2 +
                +stru.NecCompListaP3 + stru.NecCompListaP4;

            return result;
        }
    }
}