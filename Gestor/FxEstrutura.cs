using System;
using Gestor.Models;
using System.Linq;

namespace Gestor
{
    public static class FxEstrutura
    {
        public static string DescCompProc(Estrutura register)   // G
        {
            string descCompProc = "";
            using (var db = new ApplicationDbContext())
            {
                var insumo = db.Insumos.SingleOrDefault(i => i.Apelido == register.Item);

                if (insumo != null) descCompProc = insumo.Descricao;
                else
                {
                    var produto = db.Produtos.SingleOrDefault(i => i.Apelido == register.Item);

                    if (produto != null) descCompProc = produto.Descricao;
                    else
                    {
                        if (register.Sequencia.Tipo.Substring(0, 1) == XmlReader.Read("SequenciaE1").Substring(0, 1))
                        {
                            var operando = db.Operacoes.SingleOrDefault(o => o.CodigoOperacao == register.Item);
                            if (operando != null)
                            {
                                descCompProc = $"Oper. de {operando.Descricao}";
                            }

                            else
                            {
                                DbLogger.Log(Reason.Error, $"DescComProc: Código {register.Item} não encontrado");
                                descCompProc = "Erro";
                            }
                        }
                    }
                } 
            }

            return descCompProc;
        }

        public static string TipoItemCusto(Estrutura register)      // Q
        {
            string tipoItemCusto = "";
            string boh = register.Produto.Apelido;
            string mah = register.Item;

            if (register.Sequencia.Descricao != "")
            {
                using (var db = new ApplicationDbContext())
                {
                    string tipoNaoInformado = XmlReader.Read("TipoNaoInformado");
                    var insumo = db.Insumos.SingleOrDefault(i => i.Apelido == register.Item);

                    if (insumo == null)
                    {
                        var produto = db.Produtos.SingleOrDefault(p => p.Apelido == register.Item);

                        if (produto == null)
                        {
                            var operacao = db.Operacoes.SingleOrDefault(o => o.CodigoOperacao == register.Item);

                            if (operacao == null)
                            {
                                DbLogger.Log(Reason.Error, $"Código {register.Item} não encontrado em Operações");
                                tipoItemCusto = Global.Erro;
                            }

                            else tipoItemCusto = $"c-MOD Setor {operacao.SetorProducao}";
                        }

                        else tipoItemCusto = db.Tipos.Single(t => t.TipoId == produto.TipoId).Descricao;
                    }

                    else tipoItemCusto = db.Tipos.First(i => i.TipoId == insumo.TipoId).Descricao; 
                }
            }

            return tipoItemCusto;
        }

        public static int UnidadeCompraId(Estrutura register)      // H
        {
            int result;
            using (var db = new ApplicationDbContext())
            {
                string unidadeNaoInformada = XmlReader.Read("UnidadeNaoInformada");
                string sequenciaE1 = XmlReader.Read("SequenciaE1").Substring(0, 1);
                string unidadeHora = XmlReader.Read("UnidadeHora");
                string unidade = XmlReader.Read("UnidadeUnidade");
                result = db.Unidades.Single(u => u.Descricao == unidadeNaoInformada).UnidadeId;

                if (register.Sequencia.Descricao != "")
                {
                    if (register.TpItmCst == XmlReader.Read("Insumos"))
                    {
                        var insumo = db.Insumos.SingleOrDefault(i => i.Apelido == register.Item);
                        if (insumo == null)
                            DbLogger.Log(Reason.Error, $"Procura por insumo {register.Item} com erro em FxEstrutura.UnidadeCompraId");
                        else result = insumo.UnidadeConsumoId;
                    }

                    else
                    {
                        if (register.TpItmCst == XmlReader.Read("Manufaturado"))
                        {
                            var produto = db.Produtos.SingleOrDefault(p => p.Apelido == register.Item);

                            if (produto == null)
                                DbLogger.Log(Reason.Error, $"Procura por produto {register.Item} com erro em FxEstrutura.UnidadeCompraId");
                            else result = produto.UnidadeId;
                        }

                        else
                        {
                            if (register.Sequencia.Tipo.Substring(0, 1) == sequenciaE1)
                                result = db.Unidades.Single(u => u.Descricao == unidadeHora).UnidadeId;
                            else result = db.Unidades.Single(u => u.Descricao == unidade).UnidadeId;
                        }
                    }
                } 
            }

            return result;
        }

        public static float CustoUnitCompra(Estrutura estrutura)        // I
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                if (estrutura.Item != "" && estrutura.Item != XmlReader.Read("ItemNaoExiste") && estrutura.TpItmCst != Global.Erro)
                {
                    string comp = XmlReader.Read("Insumos");
                    string tpItmCstComp = estrutura.TpItmCst + Global.Space20;

                    if (tpItmCstComp.Substring(0, comp.Length) == comp)
                        result = db.Insumos.Single(i => i.Apelido == estrutura.Item).CustoUndCnsm;
                    else
                    {
                        comp = XmlReader.Read("Manufaturado");

                        if (tpItmCstComp.Substring(0, comp.Length) == comp)
                            result = db.Produtos.Single(p => p.Apelido == estrutura.Item).CustODirTotal;
                        else
                            result = db.Operacoes.Single(o => o.CodigoOperacao == estrutura.Item).Custo;
                    }
                } 
            }

            return result;
        }

        public static float QtEftvUntrCmpnt(Estrutura estrutura)        // O
        
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                float a = estrutura.Onera
                       ? 1
                       : -1;

                string sucata = XmlReader.Read("Sucata").ToLower();
                string subproduto = XmlReader.Read("Subproduto").ToLower();
                int id = estrutura.CategoriaId;
                string comp = db.Categorias.Find(id).Descricao.ToLower();

                float kd = comp.Contains(sucata)
                    || comp.Contains(subproduto)
                    ? 1
                    : 1 / (1 - estrutura.Perda);

                float c = Math.Abs(estrutura.QtdCusto) > Global.Tolerance
                    ? estrutura.Lote / estrutura.QtdCusto * kd
                    : 0;

                float b = 1;

                if (estrutura.Sequencia.Tipo.Substring(0, 1) == XmlReader.Read("SequenciaE1").Substring(0, 1))
                {
                    var operacao = db.Operacoes.SingleOrDefault(o => o.CodigoOperacao == estrutura.Item);
                    if (operacao != null) b = operacao.TaxaOcupacao;
                }

                result = a * b * c; 
            }

            return result;
    }

        public static float CstCmprUndPrd(Estrutura estrutura)      // P
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string subproduto = XmlReader.Read("Subproduto").ToLower();
                string sucata = XmlReader.Read("Sucata").ToLower();
                var boh = estrutura.Item;
                int id = estrutura.CategoriaId;
                string comp = db.Categorias.Find(id).Descricao.ToLower();

                float r = comp.Contains(subproduto) || comp.Contains(sucata)
                    ? 1 - estrutura.Perda
                    : 1;

                result = estrutura.QtEftvUntrCmpnt * estrutura.CustoUnitCompra * r; 
            }

            return result;
        }

        public static float PartCusto(Estrutura estrutura)      // N
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                var stru = db.Estruturas.Where(e => e.Produto.Apelido == estrutura.Produto.Apelido);

                if (stru.Any())
                {
                    float soma = stru.Sum(e => e.CstCmprUndPrd);
                    result = Math.Abs(soma) < Global.Tolerance
                        ? 0
                        : estrutura.CstCmprUndPrd / soma;
                } 
            }

            return result;
        }

        public static string AlrtSbPrdt(Estrutura estrutura)        // R
        {
            string result;
            using (var db = new ApplicationDbContext())
            {
                var produto = db.Produtos.SingleOrDefault(p => p.Apelido == estrutura.Item);

                result = produto != null
                    ? db.ClassesCusto.Single(c => c.ClasseCustoId == produto.ClasseCustoId).Descricao
                    : ""; 
            }

            return result;
        }

        public static float TempMaq(Estrutura estrutura)        // S
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                float quociente = 0;
                string tpItmCst = $"{estrutura.TpItmCst}{Global.Space20}";
                var operacao = db.Operacoes.SingleOrDefault(o => o.CodigoOperacao == estrutura.Item);

                //if (operacao == null)
                //    DbLogger.Log(Reason.Error, $"FxEstrutura.TempMaq resultou em item de operação ({estrutura.Item}) inexistente");
                //else quociente = operacao.TaxaOcupacao;

                if (operacao != null) quociente = operacao.TaxaOcupacao;

                result = (tpItmCst.Substring(0, 5) == "c-MOD") && (Math.Abs(quociente) > Global.Tolerance)
                    ? estrutura.QtEftvUntrCmpnt / quociente
                    : 0; 
            }

            return result;
        }

        public static float QtdUndd(Estrutura estrutura)
        {
            return estrutura.Produto.QtdUnid;

        }

        public static float PsLiqdFnl(Estrutura estrutura)      // Y
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                string unidade = db.Unidades.Single(u => u.UnidadeId == estrutura.UnidadeCompraId).Apelido;
                result = Math.Abs(estrutura.QtdCusto) > Global.Tolerance
                    && estrutura.Sequencia.Tipo == "A"
                    && unidade == "kg"
                    ? estrutura.Lote / estrutura.QtdCusto
                    : 0; 
            }

            return result;
        }

        public static float PesoLiqPrec(Estrutura estrutura)    // Z
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                string sequencia = XmlReader.Read("SequenciaA");
                string unidade = db.Unidades.Single(u => u.UnidadeId == estrutura.UnidadeCompraId).Apelido;

                if (estrutura.Sequencia.Tipo == sequencia
                    && estrutura.TpItmCst == XmlReader.Read("Manufaturado")
                    && unidade != "kg")
                {
                    var produto = db.Estruturas.Where(e => e.Produto.Apelido == estrutura.Item);
                    if (produto.Any() && (Math.Abs(estrutura.QtdCusto) > Global.Tolerance))
                        result = produto.Sum(e => e.PsLiqdFnl) * estrutura.Lote / estrutura.QtdCusto;
                } 
            }

            return result;
        }

        public static float HrsModFnl(Estrutura estrutura)      // W
        {
            float result = Math.Abs(estrutura.QtdCusto) > Global.Tolerance
                && estrutura.Sequencia.Tipo.Substring(0, 1) == XmlReader.Read("SequenciaE1").Substring(0, 1)
                ? estrutura.QtEftvUntrCmpnt
                : 0;

            return result;
        }

        public static float HrsModPrec1(Estrutura estrutura)        // X
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                var boh = estrutura.Produto.Apelido;
                var mah = estrutura.Item;
                result = estrutura.TpItmCst == XmlReader.Read("Manufaturado") && estrutura.Onera
                    ? db.Produtos.Single(p => p.Apelido == estrutura.Item).HorasModUltmEtapa * estrutura.QtEftvUntrCmpnt
                    : 0; 
            }

            return result;
        }

        public static float HrsModPrec2(Estrutura estrutura)        // Y
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                result = estrutura.TpItmCst == XmlReader.Read("Manufaturado") && estrutura.Onera
                        ? db.Produtos.Single(p => p.Apelido == estrutura.Item).HorasModEtapa1 * estrutura.QtEftvUntrCmpnt
                        : 0; 
            }

            return result;
        }

        public static string IdProd(Estrutura estrutura)        // Z
        {
            string result;
            ;
            using (var db = new ApplicationDbContext())
            {
                var produto = db.Produtos.SingleOrDefault(p => p.Id == estrutura.ProdutoId);

                if (produto == null)
                {
                    DbLogger.Log(Reason.Error, $"Erro: Produto {estrutura.ProdutoId} não encontrado");
                    return "Erro";
                }

                var unidade = db.Unidades.Single(u => u.UnidadeId == estrutura.UnidadeId);
                result = $"{produto.Descricao}-{produto.Apelido}-{unidade.Apelido}";
            }
            return result;
        }

        public static string IdCmpnt(Estrutura estrutura)       // AA
        {
            string result;
            using (var db = new ApplicationDbContext())
            {
                string unidade = db.Unidades.Single(u => u.UnidadeId == estrutura.UnidadeCompraId).Apelido;
                result = $"{estrutura.Item}-{estrutura.DescCompProc}-{unidade}";
            }

            return result;
        }

        public static float PdrHoraria(Estrutura estrutura)     // AB
        {
            float result = 0;

            if (estrutura.Sequencia.Tipo.Substring(0, 1) == XmlReader.Read("SequenciaE1").Substring(0, 1))
            {
                if (Math.Abs(estrutura.Lote) > Global.Tolerance)
                {
                    result = estrutura.QtdCusto / estrutura.Lote / (1 - estrutura.Perda);
                }
            }

            return result;
        }

        public static string ProdComp(Estrutura estrutura)      // AC
        {
            return $"{estrutura.Produto.Apelido}-{estrutura.Item}";
        }

        public static float CstIndividual(Estrutura estrutura)      // Q
        {
            float result;
            using (var db = new ApplicationDbContext())
            {
                float quantidade = db.Produtos.Single(p => p.Apelido == estrutura.Produto.Apelido).QtdUnid;
                result = (Math.Abs(quantidade) > Global.Tolerance)
                    ? estrutura.CstCmprUndPrd / quantidade
                    : 0; 
            }

            return result;
        }

        public static string RefAuxProduto(Estrutura estrutura)     // S (01/2018)
        {
            string result = "--";
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    var produto = db.Produtos.Find(estrutura.ProdutoId);
                    result = produto.RefAuxiliarProduto;
                }
                catch (Exception e)
                {
                    DbLogger.Log(Reason.Info, $"Produto com Id {estrutura.ProdutoId} não encontrado em FxEstrutura.RefAuxProduto. Erro: {e.Message}");
                } 
            }

            return result;
        }

        public static float CstMtrlDrt(Estrutura estrutura)     // AE
        {
            float result = 0;

            if (estrutura.Sequencia.Tipo == XmlReader.Read("SequenciaB") ||
                estrutura.Sequencia.Tipo == XmlReader.Read("SequenciaC") ||
                estrutura.Sequencia.Tipo == XmlReader.Read("SequenciaD") ||
                estrutura.Sequencia.Tipo == XmlReader.Read("SequenciaA") &&
                estrutura.TpItmCst == XmlReader.Read("Insumos"))
            {
                result = estrutura.CstCmprUndPrd;
            }

            return result;
        }

        public static float CstMtrlPrcd1(Estrutura estrutura)       // AF
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                if (estrutura.Sequencia.Tipo == XmlReader.Read("SequenciaA") && estrutura.TpItmCst == XmlReader.Read("Manufaturado"))
                    result = db.Produtos.Single(p => p.Apelido == estrutura.Item).CstMatUltmEtapa * estrutura.QtEftvUntrCmpnt; 
            }

            return result;
        }

        public static float CstMtrlPrcd2(Estrutura estrutura)       // AG
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                if (estrutura.Sequencia.Tipo == XmlReader.Read("SequenciaA") && estrutura.TpItmCst == XmlReader.Read("Manufaturado"))
                    result = db.Produtos.Single(p => p.Apelido == estrutura.Item).CstMatEtapa1 * estrutura.QtEftvUntrCmpnt; 
            }

            return result;
        }

        public static float CstMtrlPrcd3(Estrutura estrutura)       // AH
        {
            float result = 0;
            using (var db = new ApplicationDbContext())
            {
                if (estrutura.Sequencia.Tipo == XmlReader.Read("SequenciaA") && estrutura.TpItmCst == XmlReader.Read("Manufaturado"))
                    result = db.Produtos.Single(p => p.Apelido == estrutura.Item).CstMatEtapa2 * estrutura.QtEftvUntrCmpnt; 
            }

            return result;
        }

        public static int Categoria(Estrutura estrutura)     // U
        {
            int result;
            using (var db = new ApplicationDbContext())
            {
                var produto = db.Produtos.Find(estrutura.ProdutoId);
                var categoria = db.Categorias.Find(produto.CategoriaId);
                result = categoria.CategoriaId; 
            }

            return result;
        }
    }
}