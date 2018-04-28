namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetifyNumerationInPlaejVendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos01", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos12");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "PstStNacAnoMenos12", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejVendas", "PstStNacAnoMenos01");
        }
    }
}
