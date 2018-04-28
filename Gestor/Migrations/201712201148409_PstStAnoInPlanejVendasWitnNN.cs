namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PstStAnoInPlanejVendasWitnNN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos09", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos08", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos07", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos06", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos05", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos04", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos03", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos02", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAno00", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos9");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos8");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos7");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos6");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos5");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos4");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos3");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos2");
            DropColumn("dbo.PlanejVendas", "PstStNacAno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "PstStNacAno", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos2", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos3", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos4", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos5", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos6", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos7", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos8", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos9", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "PstStNacAno00");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos02");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos03");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos04");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos05");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos06");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos07");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos08");
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos09");
        }
    }
}
