//
// Sem utilidade a partir da vesão janeiro 2018. Mantida para e eventualidade de um cálculo, sem ser percebido, ainda restar na sua depedência
//

using System;

namespace Gestor
{
    public static class FxDfxProdRev
    {
        public static float ValorCompra(Models.DfxProdRev dfx)        // G
        {
            return dfx.QtdCompra * dfx.PrecoCompra;
        }

        public static float RateioDfixProduto(Models.DfxProdRev dfx)     // H
        {
            // **Depende de Desp Fixas em Planilha 2, com erro

            return 0;
        }

        public static float RateioDfixProdutoUnitario(Models.DfxProdRev dfx)        // I
        {
            float result = Math.Abs(dfx.QtdCompra) > Global.Tolerance
                ? dfx.RateioDfixProduto / dfx.QtdCompra
                : float.MaxValue;

            return result;
        }

        public static float DespsFabrica(Models.DfxProdRev dfx)     // K
        {
            // **Depende de Desp Fixas em Planilha 2, com erro

            return 0;
        }

        public static float DespsDepComercial(Models.DfxProdRev dfx)     // L
        {
            // **Depende de Desp Fixas em Planilha 2, com erro

            return 0;
        }

        public static float DespsDeptAdminLog(Models.DfxProdRev dfx)     // M
        {
            // **Depende de Desp Fixas em Planilha 2, com erro

            return 0;
        }

        public static int QtdRolos(Models.DfxProdRev dfx)     // N
        {
            return dfx.QtdCompra * dfx.QtdUnidade;
        }

        public static float RateioDfixUnidade(Models.DfxProdRev dfx)        // I
        {
            float result = Math.Abs(dfx.QtdUnidade) > Global.Tolerance
                ? dfx.RateioDfixUnidade / dfx.QtdUnidade
                : float.MaxValue;

            return result;
        }

        public static float ProporcaoCusto(Models.DfxProdRev dfx, float soma)     // N
        {
            float result = Math.Abs(soma) > Global.Tolerance
                ? dfx.ValorCompra / soma
                : float.MaxValue;

            return result;
        }

        public static float ProporcaoEmCxs(Models.DfxProdRev dfx, float soma)     // N
        {
            float result = Math.Abs(soma) > Global.Tolerance
                ? dfx.QtdCompra / soma
                : float.MaxValue;

            return result;
        }
    }
}