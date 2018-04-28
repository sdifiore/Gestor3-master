namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropInsumosXtd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InsumoXtds", "Comum_ComumId", "dbo.Comums");
            DropForeignKey("dbo.InsumoXtds", "FinalidadeId", "dbo.Finalidades");
            DropForeignKey("dbo.InsumoXtds", "UnddId", "dbo.Unidades");
            DropIndex("dbo.InsumoXtds", new[] { "FinalidadeId" });
            DropIndex("dbo.InsumoXtds", new[] { "UnddId" });
            DropIndex("dbo.InsumoXtds", new[] { "Comum_ComumId" });
            DropTable("dbo.InsumoXtds");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InsumoXtds",
                c => new
                    {
                        InsuMoXtdId = c.Int(nullable: false, identity: true),
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
                        BaseId = c.Int(nullable: false),
                        Comum_ComumId = c.Int(),
                    })
                .PrimaryKey(t => t.InsuMoXtdId);
            
            CreateIndex("dbo.InsumoXtds", "Comum_ComumId");
            CreateIndex("dbo.InsumoXtds", "UnddId");
            CreateIndex("dbo.InsumoXtds", "FinalidadeId");
            AddForeignKey("dbo.InsumoXtds", "UnddId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
            AddForeignKey("dbo.InsumoXtds", "FinalidadeId", "dbo.Finalidades", "FinalidadeId", cascadeDelete: true);
            AddForeignKey("dbo.InsumoXtds", "Comum_ComumId", "dbo.Comums", "ComumId");
        }
    }
}
