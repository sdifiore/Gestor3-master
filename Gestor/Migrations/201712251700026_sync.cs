namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sync : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos09", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos08", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos07", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos06", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos05", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos04", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos03", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos02", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos01", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAno00", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos12");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos9");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos8");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos7");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos6");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos5");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos4");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos3");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos2");
            DropColumn("dbo.PlanejVendas", "PqQtNacAno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "PqQtNacAno", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos2", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos3", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos4", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos5", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos6", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos7", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos8", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos9", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "PqQtNacAnoMenos12", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "PqQtNacAno00");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos01");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos02");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos03");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos04");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos05");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos06");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos07");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos08");
            DropColumn("dbo.PlanejVendas", "PqQtNacAnoMenos09");
        }
    }
}
