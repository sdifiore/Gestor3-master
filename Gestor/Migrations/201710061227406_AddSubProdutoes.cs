namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubProdutoes : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.SubProdutoId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubProdutoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.SubProdutoes", new[] { "ProdutoId" });
            DropTable("dbo.SubProdutoes");
        }
    }
}
