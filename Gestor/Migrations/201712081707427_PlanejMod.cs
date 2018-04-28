namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanejMod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanejMods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperacaoId = c.Int(nullable: false),
                        UnidadeId = c.Int(nullable: false),
                        SomaDe1 = c.Single(nullable: false),
                        SomaDe2 = c.Single(nullable: false),
                        SomaDe3 = c.Single(nullable: false),
                        SomaDe4 = c.Single(nullable: false),
                        SomaDe5 = c.Single(nullable: false),
                        SomaDe6 = c.Single(nullable: false),
                        SomaDe7 = c.Single(nullable: false),
                        SomaDe8 = c.Single(nullable: false),
                        SomaDe9 = c.Single(nullable: false),
                        SomaDe10 = c.Single(nullable: false),
                        SomaDe11 = c.Single(nullable: false),
                        SomaDe12 = c.Single(nullable: false),
                        AnoMenos11 = c.Single(nullable: false),
                        AnoMenos10 = c.Single(nullable: false),
                        AnoMenos9 = c.Single(nullable: false),
                        AnoMenos8 = c.Single(nullable: false),
                        AnoMenos7 = c.Single(nullable: false),
                        AnoMenos6 = c.Single(nullable: false),
                        AnoMenos5 = c.Single(nullable: false),
                        AnoMenos4 = c.Single(nullable: false),
                        AnoMenos3 = c.Single(nullable: false),
                        AnoMenos2 = c.Single(nullable: false),
                        AnoMenos1 = c.Single(nullable: false),
                        Ano = c.Single(nullable: false),
                        SetorId = c.Int(nullable: false),
                        MediaMensal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operacaos", t => t.OperacaoId, cascadeDelete: true)
                .ForeignKey("dbo.Setors", t => t.SetorId, cascadeDelete: false)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.OperacaoId)
                .Index(t => t.UnidadeId)
                .Index(t => t.SetorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanejMods", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.PlanejMods", "SetorId", "dbo.Setors");
            DropForeignKey("dbo.PlanejMods", "OperacaoId", "dbo.Operacaos");
            DropIndex("dbo.PlanejMods", new[] { "SetorId" });
            DropIndex("dbo.PlanejMods", new[] { "UnidadeId" });
            DropIndex("dbo.PlanejMods", new[] { "OperacaoId" });
            DropTable("dbo.PlanejMods");
        }
    }
}
