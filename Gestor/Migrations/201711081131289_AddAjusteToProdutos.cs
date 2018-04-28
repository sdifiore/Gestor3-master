namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAjusteToProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "CustoFixoTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "MoiFabricacao", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "OutrosCustosFab", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "ComacsComtexFpv", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustoFixoAdminFpv", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "RsMoiDespFabHMod", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "RsSgNAHMod", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustoFixoTotalAnr", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "MoiFabricAnr", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "OutrosCustosFabricAnr", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustoFixoComacsCmtexAnr", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustoFixoAdminAnr", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "MedidaFitaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "MedidaFitaId");
            AddForeignKey("dbo.Produtoes", "MedidaFitaId", "dbo.MedidaFitas", "MedidaFitaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "MedidaFitaId", "dbo.MedidaFitas");
            DropIndex("dbo.Produtoes", new[] { "MedidaFitaId" });
            DropColumn("dbo.Produtoes", "MedidaFitaId");
            DropColumn("dbo.Produtoes", "CustoFixoAdminAnr");
            DropColumn("dbo.Produtoes", "CustoFixoComacsCmtexAnr");
            DropColumn("dbo.Produtoes", "OutrosCustosFabricAnr");
            DropColumn("dbo.Produtoes", "MoiFabricAnr");
            DropColumn("dbo.Produtoes", "CustoFixoTotalAnr");
            DropColumn("dbo.Produtoes", "RsSgNAHMod");
            DropColumn("dbo.Produtoes", "RsMoiDespFabHMod");
            DropColumn("dbo.Produtoes", "CustoFixoAdminFpv");
            DropColumn("dbo.Produtoes", "ComacsComtexFpv");
            DropColumn("dbo.Produtoes", "OutrosCustosFab");
            DropColumn("dbo.Produtoes", "MoiFabricacao");
            DropColumn("dbo.Produtoes", "CustoFixoTotal");
        }
    }
}
