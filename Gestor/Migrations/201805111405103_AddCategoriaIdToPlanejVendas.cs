namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaIdToPlanejVendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "CategoriaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "CategoriaId");
        }
    }
}
