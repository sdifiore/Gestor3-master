namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameQtExpAnoMenosWithNN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos09", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos08", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos07", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos06", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos05", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos04", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos03", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos02", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAno00", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos9");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos8");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos7");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos6");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos5");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos4");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos3");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos2");
            DropColumn("dbo.PlanejVendas", "QtExpAno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "QtExpAno", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos2", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos3", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos4", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos5", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos6", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos7", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos8", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QtExpAnoMenos9", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "QtExpAno00");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos02");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos03");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos04");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos05");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos06");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos07");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos08");
            DropColumn("dbo.PlanejVendas", "QtExpAnoMenos09");
        }
    }
}
