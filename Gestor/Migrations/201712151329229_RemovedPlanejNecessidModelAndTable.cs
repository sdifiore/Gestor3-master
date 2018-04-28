namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPlanejNecessidModelAndTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlanejNecessids", "EstruturaId", "dbo.Estruturas");
            DropIndex("dbo.PlanejNecessids", new[] { "EstruturaId" });
            DropTable("dbo.PlanejNecessids");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlanejNecessids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstruturaId = c.Int(nullable: false),
                        SetorProducao = c.String(maxLength: 128),
                        Categoria = c.String(maxLength: 128),
                        Familia = c.String(maxLength: 128),
                        ListaPlanejProducao = c.Single(nullable: false),
                        NeedComponProducao = c.Single(nullable: false),
                        ListaNecessProdNivel1 = c.Single(nullable: false),
                        NecCompListaP1 = c.Single(nullable: false),
                        ListaNecessProdNivel2 = c.Single(nullable: false),
                        NecCompListaP2 = c.Single(nullable: false),
                        ListaNecessProdNivel3 = c.Single(nullable: false),
                        NecCompListaP3 = c.Single(nullable: false),
                        ListaNecessProdNivel4 = c.Single(nullable: false),
                        NecCompListaP4 = c.Single(nullable: false),
                        NecTotalComponente = c.Single(nullable: false),
                        Mes1 = c.Single(nullable: false),
                        Mes2 = c.Single(nullable: false),
                        Mes3 = c.Single(nullable: false),
                        Mes4 = c.Single(nullable: false),
                        Mes5 = c.Single(nullable: false),
                        Mes6 = c.Single(nullable: false),
                        Mes7 = c.Single(nullable: false),
                        Mes8 = c.Single(nullable: false),
                        Mes9 = c.Single(nullable: false),
                        Mes10 = c.Single(nullable: false),
                        Mes11 = c.Single(nullable: false),
                        Mes12 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PlanejNecessids", "EstruturaId");
            AddForeignKey("dbo.PlanejNecessids", "EstruturaId", "dbo.Estruturas", "Id", cascadeDelete: true);
        }
    }
}
