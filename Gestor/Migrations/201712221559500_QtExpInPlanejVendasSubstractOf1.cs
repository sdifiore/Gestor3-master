namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QtExpInPlanejVendasSubstractOf1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos01", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos12");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos12", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos01");
        }
    }
}
