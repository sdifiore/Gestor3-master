namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinkEstruturaToProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Estruturas", "ProdutoId");
            AddForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "ProdutoId" });
            DropColumn("dbo.Estruturas", "ProdutoId");
        }
    }
}
