namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteProdutos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AjusteProdutoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        CustoFixoTotal = c.Single(nullable: false),
                        MoiFabricacao = c.Single(nullable: false),
                        OutrosCustosFab = c.Single(nullable: false),
                        ComacsComtexFpv = c.Single(nullable: false),
                        CustoFixoAdminFpv = c.Single(nullable: false),
                        RsMoiDespFabHMod = c.Single(nullable: false),
                        RsSgNAHMod = c.Single(nullable: false),
                        CustoFixoTotalAnr = c.Single(nullable: false),
                        MoiFabricAnr = c.Single(nullable: false),
                        OutrosCustosFabricAnr = c.Single(nullable: false),
                        CustoFixoComacsCmtexAnr = c.Single(nullable: false),
                        CustoFixoAdminAnr = c.Single(nullable: false),
                        MedidaFitaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedidaFitas", t => t.MedidaFitaId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.MedidaFitaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AjusteProdutoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.AjusteProdutoes", "MedidaFitaId", "dbo.MedidaFitas");
            DropIndex("dbo.AjusteProdutoes", new[] { "MedidaFitaId" });
            DropIndex("dbo.AjusteProdutoes", new[] { "ProdutoId" });
            DropTable("dbo.AjusteProdutoes");
        }
    }
}
