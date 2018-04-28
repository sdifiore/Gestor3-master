namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuboTrabalhado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CuboTrabalhadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pedido = c.String(),
                        AnoPedido = c.String(),
                        MesPedido = c.String(),
                        DataPedido = c.DateTime(nullable: false),
                        Cliente = c.String(),
                        Estado = c.String(),
                        Cidade = c.String(),
                        Regiao = c.String(),
                        Codigo = c.String(),
                        Produto = c.String(),
                        Categoria = c.String(),
                        Familia = c.String(),
                        Linha = c.String(),
                        Marca = c.String(),
                        Vendedor = c.String(),
                        FormaPagamento = c.String(),
                        DataValidade = c.DateTime(nullable: false),
                        TipoVenda = c.String(),
                        DataFaturamento = c.DateTime(nullable: false),
                        NotaFiscal = c.String(),
                        Quantidade = c.Single(nullable: false),
                        ValorUnitario = c.Single(nullable: false),
                        ReceitaBruta = c.Single(nullable: false),
                        ValorIpi = c.Single(nullable: false),
                        ValorST = c.Single(nullable: false),
                        PrazoPagMedio = c.Int(nullable: false),
                        FatuBruto = c.Single(nullable: false),
                        MesCadastro = c.String(),
                        MesFatura = c.String(),
                        Faturado = c.Boolean(nullable: false),
                        MesEntregue = c.String(),
                        ClienteNfDataFat = c.String(),
                        CodigoAjustado = c.String(),
                        CodNomeProdutoUnidade = c.String(),
                        UnidadeId = c.Int(nullable: false),
                        QuantAjustada = c.Single(nullable: false),
                        PesoBruto = c.Single(nullable: false),
                        NaturCli = c.String(),
                        TipoCliente = c.String(),
                        CategoriaCliente = c.String(),
                        SegmentoCliente = c.String(),
                        Grupo = c.String(),
                        PrazoEntrega = c.Int(nullable: false),
                        TaxaDolar = c.Single(nullable: false),
                        FatBrutoUsd = c.Single(nullable: false),
                        PrecoIndividual = c.Single(nullable: false),
                        ReceitaLiquida = c.Single(nullable: false),
                        Comissao = c.Single(nullable: false),
                        Frete = c.Single(nullable: false),
                        CustoFinancCobranca = c.Single(nullable: false),
                        GrupoRateioId = c.Int(nullable: false),
                        AnoFaturamento = c.Int(nullable: false),
                        TemPeso = c.Boolean(nullable: false),
                        PvRsKg = c.Single(nullable: false),
                        Trimestre = c.String(),
                        M2Fitas = c.Single(nullable: false),
                        RecBrutaUsd = c.Single(nullable: false),
                        CategoProdAjustadaId = c.Int(nullable: false),
                        PeriodoEstatistico = c.String(),
                        QuantIndividualAjustada = c.Single(nullable: false),
                        IdVend = c.String(),
                        CodRegiaoOriginal = c.String(),
                        VlIcms = c.Single(nullable: false),
                        VlCom = c.String(),
                        CodProdOriginal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CuboTrabalhadoes");
        }
    }
}
