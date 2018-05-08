using Gestor.Models;
using Gestor.ViewModels;
using Gestor.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor
{
    public class Wizard
    {
        public static NavEstruturaViewModel CopyStru(int produtoId)
        {
            var estrutura = new NavEstruturaViewModel();

            using (var db = new ApplicationDbContext())
            {
                int i = 0;
                var temp = db.Estruturas.Where(e => e.ProdutoId == produtoId);
                var estruturas = new List<Estrutura>(temp);

                while (i < estruturas.Count())
                {
                    estrutura = new NavEstruturaViewModel
                    {
                        ProdutoId = estruturas[i].ProdutoId,
                        UnidadeId = estruturas[i].UnidadeId,
                        QtdCusto = estruturas[i].QtdCusto,
                        SequenciaId = estruturas[i].SequenciaId,
                        Item = estruturas[i].Item,
                        Onera = estruturas[i].Onera,
                        Lote = estruturas[i].Lote,
                        Perda = estruturas[i].Perda,
                        Observacao = estruturas[i].Observacao,
                        RefAuxiliarProduto = estruturas[i].RefAuxiliarProduto,
                    };

                    estrutura.Forward = i < estruturas.Count() ? true : false;
                    estrutura.Backward = i > 0 ? true : false;

                }
            }

            return estrutura;
        }
    }
}