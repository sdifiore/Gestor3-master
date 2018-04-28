namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHorasProdTotalFieldToPlanejVendaTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "HorasProdTotal", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "HorasProdTotal");
        }
    }
}
