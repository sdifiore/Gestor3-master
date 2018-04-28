namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsumoXtd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insumoes", "CotacaoId", "dbo.Cotacaos");
            DropForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades");
            DropForeignKey("dbo.Insumoes", "Linha_LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades");
            DropIndex("dbo.Insumoes", new[] { "CotacaoId" });
            DropIndex("dbo.Insumoes", new[] { "FinalidadeId" });
            DropIndex("dbo.Insumoes", new[] { "UnddId" });
            DropIndex("dbo.Insumoes", new[] { "Linha_LinhaId" });
            DropColumn("dbo.Insumoes", "Peso");
            DropColumn("dbo.Insumoes", "CotacaoId");
            DropColumn("dbo.Insumoes", "PrecoUsd");
            DropColumn("dbo.Insumoes", "PrecoRs");
            DropColumn("dbo.Insumoes", "Icms");
            DropColumn("dbo.Insumoes", "Ipi");
            DropColumn("dbo.Insumoes", "Pis");
            DropColumn("dbo.Insumoes", "Cofins");
            DropColumn("dbo.Insumoes", "DespExtra");
            DropColumn("dbo.Insumoes", "DespImport");
            DropColumn("dbo.Insumoes", "Ativo");
            DropColumn("dbo.Insumoes", "FinalidadeId");
            DropColumn("dbo.Insumoes", "UnddId");
            DropColumn("dbo.Insumoes", "QtdUnddConsumo");
            DropColumn("dbo.Insumoes", "QtdMltplCompra");
            DropColumn("dbo.Insumoes", "Linha_LinhaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Insumoes", "Linha_LinhaId", c => c.Int());
            AddColumn("dbo.Insumoes", "QtdMltplCompra", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "QtdUnddConsumo", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "UnddId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "FinalidadeId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Insumoes", "DespImport", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "DespExtra", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Cofins", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Pis", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Ipi", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Icms", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "PrecoRs", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "PrecoUsd", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "CotacaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "Peso", c => c.Single(nullable: false));
            CreateIndex("dbo.Insumoes", "Linha_LinhaId");
            CreateIndex("dbo.Insumoes", "UnddId");
            CreateIndex("dbo.Insumoes", "FinalidadeId");
            CreateIndex("dbo.Insumoes", "CotacaoId");
            AddForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "Linha_LinhaId", "dbo.Linhas", "LinhaId");
            AddForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades", "FinalidadeId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "CotacaoId", "dbo.Cotacaos", "CotacaoId", cascadeDelete: true);
        }
    }
}
