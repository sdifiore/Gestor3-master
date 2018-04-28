namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FaturamentoHistoricos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FatHistoricoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroPedido = c.Int(nullable: false),
                        DataPedido = c.DateTime(nullable: false),
                        Cliente = c.String(maxLength: 64),
                        Estado = c.String(maxLength: 24),
                        Cidade = c.String(maxLength: 32),
                        Regiao = c.String(maxLength: 24),
                        ProdutoId = c.Int(nullable: false),
                        Vendedor = c.String(maxLength: 64),
                        FormaPagamento = c.String(maxLength: 16),
                        DataValidade = c.DateTime(nullable: false),
                        TipoVenda = c.String(maxLength: 3),
                        DataFaturamento = c.DateTime(nullable: false),
                        NotaFiscal = c.Int(nullable: false),
                        Quantidade = c.Single(nullable: false),
                        ValorUnitario = c.Single(nullable: false),
                        ValorMercadoria = c.Single(nullable: false),
                        ValorIpi = c.Single(nullable: false),
                        ValorSubstTributaria = c.Single(nullable: false),
                        PrazoMedioRecebimento = c.Int(nullable: false),
                        RecBruta = c.Single(nullable: false),
                        FaturBruto = c.Single(nullable: false),
                        MesCadastro = c.String(maxLength: 7),
                        AnoMesFatura = c.String(maxLength: 7),
                        Situacao = c.String(maxLength: 16),
                        MesEntrega = c.String(maxLength: 7),
                        ClientePedido = c.String(maxLength: 128),
                        ProdutoAjustadoId = c.Int(nullable: false),
                        NaturCli = c.String(maxLength: 1),
                        PesoProduto = c.Single(nullable: false),
                        TipoCliente = c.String(maxLength: 10),
                        CategoriaCliente = c.String(maxLength: 32),
                        SegmentoCliente = c.String(maxLength: 32),
                        Grupo = c.String(maxLength: 64),
                        PrazoEntrega = c.Int(nullable: false),
                        TxDolar = c.Single(nullable: false),
                        FatBrutoUsd = c.Single(nullable: false),
                        PrecoIndividual = c.Single(nullable: false),
                        ReceitaLiquida = c.Single(nullable: false),
                        Comissao = c.Single(nullable: false),
                        Frete = c.Single(nullable: false),
                        CstFinBobranca = c.Single(nullable: false),
                        QuantAjustada = c.Single(nullable: false),
                        Icms = c.Single(nullable: false),
                        PrazoFatur = c.Single(nullable: false),
                        HorasMod = c.Single(nullable: false),
                        ComGvComacs = c.Single(nullable: false),
                        DescrProdAjustado = c.String(maxLength: 64),
                        ProdCategoriaAjustado = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoAjustadoId, cascadeDelete: false)
                .Index(t => t.ProdutoId)
                .Index(t => t.ProdutoAjustadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FatHistoricoes", "ProdutoAjustadoId", "dbo.Produtoes");
            DropForeignKey("dbo.FatHistoricoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.FatHistoricoes", new[] { "ProdutoAjustadoId" });
            DropIndex("dbo.FatHistoricoes", new[] { "ProdutoId" });
            DropTable("dbo.FatHistoricoes");
        }
    }
}
