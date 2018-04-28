namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TesteFatHist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TesteFatHists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pedido = c.String(maxLength: 16),
                        DataPedido = c.DateTime(nullable: false),
                        Cliente = c.String(maxLength: 256),
                        UF = c.String(maxLength: 2),
                        Cidade = c.String(maxLength: 64),
                        Regiao = c.String(maxLength: 32),
                        Codigo = c.String(maxLength: 6),
                        Produto = c.String(maxLength: 128),
                        CategoriaId = c.Int(nullable: false),
                        FamiliaId = c.Int(nullable: false),
                        LinhaId = c.Int(nullable: false),
                        MarcaId = c.Int(nullable: false),
                        Vendedor = c.String(maxLength: 128),
                        FormaPagamento = c.String(maxLength: 32),
                        DataValidade = c.DateTime(nullable: false),
                        TipoVendaId = c.Int(nullable: false),
                        DataFaturamento = c.DateTime(nullable: false),
                        NotaFiscal = c.String(maxLength: 16),
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
                        ClienteNfDataFat = c.String(maxLength: 256),
                        CodigoAjustado = c.String(maxLength: 6),
                        CodNomeProdutoUnidade = c.String(maxLength: 256),
                        UnidadeId = c.Int(nullable: false),
                        QuantAjustada = c.Single(nullable: false),
                        PesoProduto = c.Single(nullable: false),
                        Juridico = c.Boolean(nullable: false),
                        TipoClienteId = c.Int(nullable: false),
                        CategoriaClienteId = c.Int(nullable: false),
                        SegmentoCliente = c.String(maxLength: 256),
                        Grupo = c.String(maxLength: 256),
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
                        Trimestre = c.String(maxLength: 7),
                        M2Fitas = c.Single(nullable: false),
                        RecBrutaUsd = c.Single(nullable: false),
                        CategoProdAjustadaId = c.Int(nullable: false),
                        PeriodoEstatistico = c.String(maxLength: 9),
                        QuantIndividualAjustada = c.Single(nullable: false),
                        IdVend = c.String(maxLength: 256),
                        CodRegiaoOriginal = c.String(),
                        VlIcms = c.Single(nullable: false),
                        VlCom = c.Single(nullable: false),
                        Cnpj = c.String(maxLength: 24),
                        CodProdOriginal = c.String(maxLength: 256),
                        CategoProdAjustada_CategoriaId = c.Int(),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoProdAjustada_CategoriaId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.CategoriasCliente", t => t.CategoriaClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Familias", t => t.FamiliaId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoRateios", t => t.GrupoRateioId, cascadeDelete: true)
                .ForeignKey("dbo.Linhas", t => t.LinhaId, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .ForeignKey("dbo.TiposCliente", t => t.TipoClienteId, cascadeDelete: true)
                .ForeignKey("dbo.TiposVenda", t => t.TipoVendaId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.FamiliaId)
                .Index(t => t.LinhaId)
                .Index(t => t.MarcaId)
                .Index(t => t.TipoVendaId)
                .Index(t => t.UnidadeId)
                .Index(t => t.TipoClienteId)
                .Index(t => t.CategoriaClienteId)
                .Index(t => t.GrupoRateioId)
                .Index(t => t.CategoProdAjustada_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TesteFatHists", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.TesteFatHists", "TipoVendaId", "dbo.TiposVenda");
            DropForeignKey("dbo.TesteFatHists", "TipoClienteId", "dbo.TiposCliente");
            DropForeignKey("dbo.TesteFatHists", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.TesteFatHists", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.TesteFatHists", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.TesteFatHists", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.TesteFatHists", "CategoriaClienteId", "dbo.CategoriasCliente");
            DropForeignKey("dbo.TesteFatHists", "Categoria_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.TesteFatHists", "CategoProdAjustada_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.TesteFatHists", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.TesteFatHists", new[] { "CategoProdAjustada_CategoriaId" });
            DropIndex("dbo.TesteFatHists", new[] { "GrupoRateioId" });
            DropIndex("dbo.TesteFatHists", new[] { "CategoriaClienteId" });
            DropIndex("dbo.TesteFatHists", new[] { "TipoClienteId" });
            DropIndex("dbo.TesteFatHists", new[] { "UnidadeId" });
            DropIndex("dbo.TesteFatHists", new[] { "TipoVendaId" });
            DropIndex("dbo.TesteFatHists", new[] { "MarcaId" });
            DropIndex("dbo.TesteFatHists", new[] { "LinhaId" });
            DropIndex("dbo.TesteFatHists", new[] { "FamiliaId" });
            DropTable("dbo.TesteFatHists");
        }
    }
}
