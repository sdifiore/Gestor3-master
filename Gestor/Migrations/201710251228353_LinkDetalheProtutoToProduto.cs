namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkDetalheProtutoToProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalheProdutoes", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.DetalheProdutoes", "ProdutoId");
            AddForeignKey("dbo.DetalheProdutoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalheProdutoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.DetalheProdutoes", new[] { "ProdutoId" });
            DropColumn("dbo.DetalheProdutoes", "ProdutoId");
        }
    }
}
