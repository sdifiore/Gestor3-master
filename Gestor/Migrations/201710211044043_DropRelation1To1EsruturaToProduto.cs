namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRelation1To1EsruturaToProduto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "ProdutoId" });
            DropColumn("dbo.Estruturas", "ProdutoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estruturas", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Estruturas", "ProdutoId");
            AddForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
