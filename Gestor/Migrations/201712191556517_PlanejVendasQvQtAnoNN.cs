namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanejVendasQvQtAnoNN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos09", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos08", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos07", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos06", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos05", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos04", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos03", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos02", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAno00", c => c.Single(nullable: false));
            AlterColumn("dbo.PlanejVendas", "RefAno", c => c.DateTime());
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos9");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos8");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos7");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos6");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos5");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos4");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos3");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos2");
            DropColumn("dbo.PlanejVendas", "QvQtNacAno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "QvQtNacAno", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos2", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos3", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos4", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos5", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos6", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos7", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos8", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "QvQtNacAnoMenos9", c => c.Single(nullable: false));
            AlterColumn("dbo.PlanejVendas", "RefAno", c => c.DateTime(nullable: false));
            DropColumn("dbo.PlanejVendas", "QvQtNacAno00");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos02");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos03");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos04");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos05");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos06");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos07");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos08");
            DropColumn("dbo.PlanejVendas", "QvQtNacAnoMenos09");
        }
    }
}
