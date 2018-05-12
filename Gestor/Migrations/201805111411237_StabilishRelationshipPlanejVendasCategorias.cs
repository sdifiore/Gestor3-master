namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StabilishRelationshipPlanejVendasCategorias : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PlanejVendas", "CategoriaId");
            AddForeignKey("dbo.PlanejVendas", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanejVendas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.PlanejVendas", new[] { "CategoriaId" });
        }
    }
}
