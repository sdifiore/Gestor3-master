namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRelationFromEstruiturasToProdutos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "ProdutoId" });
            RenameColumn(table: "dbo.Estruturas", name: "ProdutoId", newName: "Produto_Id");
            AlterColumn("dbo.Estruturas", "Produto_Id", c => c.Int());
            CreateIndex("dbo.Estruturas", "Produto_Id");
            AddForeignKey("dbo.Estruturas", "Produto_Id", "dbo.Produtoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estruturas", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "Produto_Id" });
            AlterColumn("dbo.Estruturas", "Produto_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Estruturas", name: "Produto_Id", newName: "ProdutoId");
            CreateIndex("dbo.Estruturas", "ProdutoId");
            AddForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
