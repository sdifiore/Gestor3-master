namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustNumeralsInQtNacForPlanejVendasTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos01", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos12");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos12", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos01");
        }
    }
}
