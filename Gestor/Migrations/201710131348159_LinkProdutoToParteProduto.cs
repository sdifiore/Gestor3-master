namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkProdutoToParteProduto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "ParteProdutoId", "dbo.ParteProdutoes");
            DropIndex("dbo.Produtoes", new[] { "ParteProdutoId" });
            AddColumn("dbo.ParteProdutoes", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParteProdutoes", "ProdutoId");
            AddForeignKey("dbo.ParteProdutoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParteProdutoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.ParteProdutoes", new[] { "ProdutoId" });
            DropColumn("dbo.ParteProdutoes", "ProdutoId");
            CreateIndex("dbo.Produtoes", "ParteProdutoId");
            AddForeignKey("dbo.Produtoes", "ParteProdutoId", "dbo.ParteProdutoes", "ParteProdutoId", cascadeDelete: true);
        }
    }
}
