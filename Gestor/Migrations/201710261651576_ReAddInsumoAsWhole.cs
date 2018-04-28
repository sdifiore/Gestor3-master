namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddInsumoAsWhole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insumoes",
                c => new
                    {
                        InsumoId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        UnidadeId = c.Int(nullable: false),
                        TipoId = c.Int(nullable: false),
                        ClasseCustoId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        FamiliaId = c.Int(nullable: false),
                        LinhaId = c.Int(nullable: false),
                        Peso = c.Single(nullable: false),
                        Cotacao = c.String(maxLength: 1024),
                        PrecoUsd = c.Single(nullable: false),
                        PrecoRs = c.Single(nullable: false),
                        Icms = c.Single(nullable: false),
                        Ipi = c.Single(nullable: false),
                        Pis = c.Single(nullable: false),
                        Cofins = c.Single(nullable: false),
                        DespExtra = c.Single(nullable: false),
                        DespImport = c.Single(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        FinalidadeId = c.Int(nullable: false),
                        UnddId = c.Int(nullable: false),
                        QtdUnddConsumo = c.Single(nullable: false),
                        QtdMltplCompra = c.Single(nullable: false),
                        FormaPgto = c.String(maxLength: 16),
                        Prazo1 = c.Int(nullable: false),
                        Prazo2 = c.Int(nullable: false),
                        PctPgto1 = c.Single(nullable: false),
                        ImportPzPagDesp = c.Int(nullable: false),
                        PrcBrtCompra = c.Single(nullable: false),
                        CrdtIcms = c.Single(nullable: false),
                        CrdtIpi = c.Single(nullable: false),
                        CrdtPis = c.Single(nullable: false),
                        CrdtCofins = c.Single(nullable: false),
                        SumCrdImpostos = c.Single(nullable: false),
                        DspImportacao = c.Single(nullable: false),
                        CustoExtra = c.Single(nullable: false),
                        Custo = c.Single(nullable: false),
                        CustoUndCnsm = c.Single(nullable: false),
                        PgtFornecImp = c.Single(nullable: false),
                        UsoStru = c.Int(nullable: false),
                        Unidade_UnidadeId = c.Int(),
                    })
                .PrimaryKey(t => t.InsumoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.ClasseCustoes", t => t.ClasseCustoId, cascadeDelete: true)
                .ForeignKey("dbo.Familias", t => t.FamiliaId, cascadeDelete: true)
                .ForeignKey("dbo.Finalidades", t => t.FinalidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Linhas", t => t.LinhaId, cascadeDelete: true)
                .ForeignKey("dbo.Tipoes", t => t.TipoId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.Unidade_UnidadeId)
                .ForeignKey("dbo.Unidades", t => t.UnddId, cascadeDelete: true)
                .Index(t => t.TipoId)
                .Index(t => t.ClasseCustoId)
                .Index(t => t.CategoriaId)
                .Index(t => t.FamiliaId)
                .Index(t => t.LinhaId)
                .Index(t => t.FinalidadeId)
                .Index(t => t.UnddId)
                .Index(t => t.Unidade_UnidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades");
            DropForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Insumoes", new[] { "Unidade_UnidadeId" });
            DropIndex("dbo.Insumoes", new[] { "UnddId" });
            DropIndex("dbo.Insumoes", new[] { "FinalidadeId" });
            DropIndex("dbo.Insumoes", new[] { "LinhaId" });
            DropIndex("dbo.Insumoes", new[] { "FamiliaId" });
            DropIndex("dbo.Insumoes", new[] { "CategoriaId" });
            DropIndex("dbo.Insumoes", new[] { "ClasseCustoId" });
            DropIndex("dbo.Insumoes", new[] { "TipoId" });
            DropTable("dbo.Insumoes");
        }
    }
}
