namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkCustoConsumoToProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustoInsumoes", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustoInsumoes", "ProdutoId");
            AddForeignKey("dbo.CustoInsumoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustoInsumoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.CustoInsumoes", new[] { "ProdutoId" });
            DropColumn("dbo.CustoInsumoes", "ProdutoId");
        }
    }
}
