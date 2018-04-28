namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVendaMesMenosNNFieldsToPlanejProducao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlanejProducaos", "PlanejVendaId", "dbo.PlanejVendas");
            DropIndex("dbo.PlanejProducaos", new[] { "PlanejVendaId" });
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos11", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos10", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos09", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos08", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos07", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos06", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos05", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos04", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos03", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos02", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos01", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejProducaos", "VendaMesMenos00", c => c.Single(nullable: false));
            DropColumn("dbo.PlanejProducaos", "PlanejVendaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejProducaos", "PlanejVendaId", c => c.Int(nullable: false));
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos00");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos01");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos02");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos03");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos04");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos05");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos06");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos07");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos08");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos09");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos10");
            DropColumn("dbo.PlanejProducaos", "VendaMesMenos11");
            CreateIndex("dbo.PlanejProducaos", "PlanejVendaId");
            AddForeignKey("dbo.PlanejProducaos", "PlanejVendaId", "dbo.PlanejVendas", "Id", cascadeDelete: true);
        }
    }
}
