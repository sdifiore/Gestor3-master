namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldPctPag1ToPlanejVendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejCompras", "PctPag1", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejCompras", "PctPag1");
        }
    }
}
