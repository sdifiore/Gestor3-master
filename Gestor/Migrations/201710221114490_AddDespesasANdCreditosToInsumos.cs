namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDespesasANdCreditosToInsumos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insumoes", "PrcBrtCompra", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "CrdtIcms", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "CrdtIpi", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "CrdtPis", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "CrdtCofins", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "SumCrdImpostos", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "DspImportacao", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insumoes", "DspImportacao");
            DropColumn("dbo.Insumoes", "SumCrdImpostos");
            DropColumn("dbo.Insumoes", "CrdtCofins");
            DropColumn("dbo.Insumoes", "CrdtPis");
            DropColumn("dbo.Insumoes", "CrdtIpi");
            DropColumn("dbo.Insumoes", "CrdtIcms");
            DropColumn("dbo.Insumoes", "PrcBrtCompra");
        }
    }
}
