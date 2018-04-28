namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelation1ToNFromProdutoToEstrutura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "Produto_Id", c => c.Int());
            CreateIndex("dbo.Estruturas", "Produto_Id");
            AddForeignKey("dbo.Estruturas", "Produto_Id", "dbo.Produtoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estruturas", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "Produto_Id" });
            DropColumn("dbo.Estruturas", "Produto_Id");
        }
    }
}
