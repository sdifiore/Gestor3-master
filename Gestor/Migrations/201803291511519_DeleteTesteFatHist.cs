namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTesteFatHist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TesteFatHists", "CategoProdAjustada_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.TesteFatHists", "Categoria_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.TesteFatHists", "CategoriaClienteId", "dbo.CategoriasCliente");
            DropForeignKey("dbo.TesteFatHists", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.TesteFatHists", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.TesteFatHists", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.TesteFatHists", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.TesteFatHists", "TipoClienteId", "dbo.TiposCliente");
            DropForeignKey("dbo.TesteFatHists", "TipoVendaId", "dbo.TiposVenda");
            DropForeignKey("dbo.TesteFatHists", "UnidadeId", "dbo.Unidades");
            DropIndex("dbo.TesteFatHists", new[] { "FamiliaId" });
            DropIndex("dbo.TesteFatHists", new[] { "LinhaId" });
            DropIndex("dbo.TesteFatHists", new[] { "MarcaId" });
            DropIndex("dbo.TesteFatHists", new[] { "TipoVendaId" });
            DropIndex("dbo.TesteFatHists", new[] { "UnidadeId" });
            DropIndex("dbo.TesteFatHists", new[] { "TipoClienteId" });
            DropIndex("dbo.TesteFatHists", new[] { "CategoriaClienteId" });
            DropIndex("dbo.TesteFatHists", new[] { "GrupoRateioId" });
            DropIndex("dbo.TesteFatHists", new[] { "CategoProdAjustada_CategoriaId" });
            DropIndex("dbo.TesteFatHists", new[] { "Categoria_CategoriaId" });
            DropTable("dbo.TesteFatHists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TesteFatHists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pedido = c.String(maxLength: 16),
                        DataPedido = c.DateTime(nullable: false),
                        Cliente = c.String(maxLength: 256),
                        UF = c.String(maxLength: 16),
                        Cidade = c.String(maxLength: 64),
                        Regiao = c.String(maxLength: 32),
                        Codigo = c.String(maxLength: 16),
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
                        CodigoAjustado = c.String(maxLength: 16),
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
                        Trimestre = c.String(maxLength: 16),
                        M2Fitas = c.Single(nullable: false),
                        RecBrutaUsd = c.Single(nullable: false),
                        CategoProdAjustadaId = c.Int(nullable: false),
                        PeriodoEstatistico = c.String(maxLength: 16),
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TesteFatHists", "Categoria_CategoriaId");
            CreateIndex("dbo.TesteFatHists", "CategoProdAjustada_CategoriaId");
            CreateIndex("dbo.TesteFatHists", "GrupoRateioId");
            CreateIndex("dbo.TesteFatHists", "CategoriaClienteId");
            CreateIndex("dbo.TesteFatHists", "TipoClienteId");
            CreateIndex("dbo.TesteFatHists", "UnidadeId");
            CreateIndex("dbo.TesteFatHists", "TipoVendaId");
            CreateIndex("dbo.TesteFatHists", "MarcaId");
            CreateIndex("dbo.TesteFatHists", "LinhaId");
            CreateIndex("dbo.TesteFatHists", "FamiliaId");
            AddForeignKey("dbo.TesteFatHists", "UnidadeId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "TipoVendaId", "dbo.TiposVenda", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "TipoClienteId", "dbo.TiposCliente", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "MarcaId", "dbo.Marcas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "CategoriaClienteId", "dbo.CategoriasCliente", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TesteFatHists", "Categoria_CategoriaId", "dbo.Categorias", "CategoriaId");
            AddForeignKey("dbo.TesteFatHists", "CategoProdAjustada_CategoriaId", "dbo.Categorias", "CategoriaId");
        }
    }
}
