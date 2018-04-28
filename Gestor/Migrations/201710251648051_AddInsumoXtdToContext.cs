namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsumoXtdToContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsumoXtds",
                c => new
                    {
                        InsuMoXtdId = c.Int(nullable: false, identity: true),
                        Peso = c.Single(nullable: false),
                        CotacaoId = c.Int(nullable: false),
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
                        FormaPgto = c.Int(nullable: false),
                        Prazo1 = c.Int(nullable: false),
                        Prazo2 = c.Int(nullable: false),
                        PctPgto1 = c.Int(nullable: false),
                        ImportPzPagDesp = c.Int(nullable: false),
                        BaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsuMoXtdId)
                .ForeignKey("dbo.Bases", t => t.BaseId, cascadeDelete: true)
                .ForeignKey("dbo.Cotacaos", t => t.CotacaoId, cascadeDelete: false)
                .ForeignKey("dbo.Finalidades", t => t.FinalidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.UnddId, cascadeDelete: false)
                .Index(t => t.CotacaoId)
                .Index(t => t.FinalidadeId)
                .Index(t => t.UnddId)
                .Index(t => t.BaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsumoXtds", "UnddId", "dbo.Unidades");
            DropForeignKey("dbo.InsumoXtds", "FinalidadeId", "dbo.Finalidades");
            DropForeignKey("dbo.InsumoXtds", "CotacaoId", "dbo.Cotacaos");
            DropForeignKey("dbo.InsumoXtds", "BaseId", "dbo.Bases");
            DropIndex("dbo.InsumoXtds", new[] { "BaseId" });
            DropIndex("dbo.InsumoXtds", new[] { "UnddId" });
            DropIndex("dbo.InsumoXtds", new[] { "FinalidadeId" });
            DropIndex("dbo.InsumoXtds", new[] { "CotacaoId" });
            DropTable("dbo.InsumoXtds");
        }
    }
}
