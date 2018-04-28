namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrpSubprodutos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubProdutoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.SubProdutoes", new[] { "ProdutoId" });
            DropTable("dbo.SubProdutoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubProdutoes",
                c => new
                    {
                        SubProdutoId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Cartucho = c.Single(nullable: false),
                        Carretel = c.Single(nullable: false),
                        CRefile = c.Single(nullable: false),
                        Jumbo216 = c.Single(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubProdutoId);
            
            CreateIndex("dbo.SubProdutoes", "ProdutoId");
            AddForeignKey("dbo.SubProdutoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
