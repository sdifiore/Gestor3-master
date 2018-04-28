namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanejProducao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanejProducaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        PlanejVendaId = c.Int(nullable: false),
                        PmpAnoMenos11 = c.Single(nullable: false),
                        PmpAnoMenos10 = c.Single(nullable: false),
                        PmpAnoMenos09 = c.Single(nullable: false),
                        PmpAnoMenos08 = c.Single(nullable: false),
                        PmpAnoMenos07 = c.Single(nullable: false),
                        PmpAnoMenos06 = c.Single(nullable: false),
                        PmpAnoMenos05 = c.Single(nullable: false),
                        PmpAnoMenos04 = c.Single(nullable: false),
                        PmpAnoMenos03 = c.Single(nullable: false),
                        PmpAnoMenos02 = c.Single(nullable: false),
                        PmpAnoMenos01 = c.Single(nullable: false),
                        PmpAnoMenos00 = c.Single(nullable: false),
                        SfmAnoMenos11 = c.Single(nullable: false),
                        SfmAnoMenos10 = c.Single(nullable: false),
                        SfmAnoMenos09 = c.Single(nullable: false),
                        SfmAnoMenos08 = c.Single(nullable: false),
                        SfmAnoMenos07 = c.Single(nullable: false),
                        SfmAnoMenos06 = c.Single(nullable: false),
                        SfmAnoMenos05 = c.Single(nullable: false),
                        SfmAnoMenos04 = c.Single(nullable: false),
                        SfmAnoMenos03 = c.Single(nullable: false),
                        SfmAnoMenos02 = c.Single(nullable: false),
                        SfmAnoMenos01 = c.Single(nullable: false),
                        SfmAnoMenos00 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlanejVendas", t => t.PlanejVendaId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: false)
                .Index(t => t.ProdutoId)
                .Index(t => t.PlanejVendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanejProducaos", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.PlanejProducaos", "PlanejVendaId", "dbo.PlanejVendas");
            DropIndex("dbo.PlanejProducaos", new[] { "PlanejVendaId" });
            DropIndex("dbo.PlanejProducaos", new[] { "ProdutoId" });
            DropTable("dbo.PlanejProducaos");
        }
    }
}
