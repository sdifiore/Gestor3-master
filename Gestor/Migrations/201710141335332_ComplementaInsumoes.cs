namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplementaInsumoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insumoes", "CotacaoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "PrecoUsd", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Icms", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Ipi", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Pis", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Cofins", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "DespExtra", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "DespImport", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Ativo", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Insumoes", "CotacaoId");
            AddForeignKey("dbo.Insumoes", "CotacaoId", "dbo.Cotacaos", "CotacaoId", cascadeDelete: false);
            DropColumn("dbo.Insumoes", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Insumoes", "Status", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Insumoes", "CotacaoId", "dbo.Cotacaos");
            DropIndex("dbo.Insumoes", new[] { "CotacaoId" });
            DropColumn("dbo.Insumoes", "Ativo");
            DropColumn("dbo.Insumoes", "DespImport");
            DropColumn("dbo.Insumoes", "DespExtra");
            DropColumn("dbo.Insumoes", "Cofins");
            DropColumn("dbo.Insumoes", "Pis");
            DropColumn("dbo.Insumoes", "Ipi");
            DropColumn("dbo.Insumoes", "Icms");
            DropColumn("dbo.Insumoes", "PrecoUsd");
            DropColumn("dbo.Insumoes", "CotacaoId");
        }
    }
}
