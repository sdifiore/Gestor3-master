namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dROPaJUSTEpRODUTOS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AjusteProdutoes", "MedidaFitaId", "dbo.MedidaFitas");
            DropForeignKey("dbo.AjusteProdutoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.AjusteProdutoes", new[] { "ProdutoId" });
            DropIndex("dbo.AjusteProdutoes", new[] { "MedidaFitaId" });
            DropTable("dbo.AjusteProdutoes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AjusteProdutoes", "MedidaFitaId");
            CreateIndex("dbo.AjusteProdutoes", "ProdutoId");
            AddForeignKey("dbo.AjusteProdutoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AjusteProdutoes", "MedidaFitaId", "dbo.MedidaFitas", "MedidaFitaId", cascadeDelete: true);
        }
    }
}
