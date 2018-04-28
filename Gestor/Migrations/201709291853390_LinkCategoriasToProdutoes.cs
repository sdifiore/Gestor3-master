namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkCategoriasToProdutoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "CategoriaId");
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            DropColumn("dbo.Produtoes", "CategoriaId");
        }
    }
}
