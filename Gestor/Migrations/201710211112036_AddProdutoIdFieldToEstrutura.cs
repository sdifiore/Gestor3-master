namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProdutoIdFieldToEstrutura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estruturas", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "Produto_Id" });
            RenameColumn(table: "dbo.Estruturas", name: "Produto_Id", newName: "ProdutoId");
            AlterColumn("dbo.Estruturas", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Estruturas", "ProdutoId");
            AddForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "ProdutoId" });
            AlterColumn("dbo.Estruturas", "ProdutoId", c => c.Int());
            RenameColumn(table: "dbo.Estruturas", name: "ProdutoId", newName: "Produto_Id");
            CreateIndex("dbo.Estruturas", "Produto_Id");
            AddForeignKey("dbo.Estruturas", "Produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
