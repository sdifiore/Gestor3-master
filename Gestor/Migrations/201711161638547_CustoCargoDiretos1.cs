namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustoCargoDiretos1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustoCargoDiretoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SetorProducao = c.String(maxLength: 32),
                        SetorId = c.Int(nullable: false),
                        Operadores = c.Int(nullable: false),
                        MoDireta = c.Single(nullable: false),
                        CodigoLiderApoio = c.String(maxLength: 2),
                        MoDiretaLiderApoio = c.Single(nullable: false),
                        HorasModOperadores = c.Single(nullable: false),
                        HorasModTotal = c.Single(nullable: false),
                        CustoTotal = c.Single(nullable: false),
                        RateioSetor20 = c.Single(nullable: false),
                        RateioSetor40 = c.Single(nullable: false),
                        RateioSetor50 = c.Single(nullable: false),
                        RateioSetor60 = c.Single(nullable: false),
                        SomaIndiretos = c.Single(nullable: false),
                        SomaDiretoIndireto = c.Single(nullable: false),
                        RateioCustoUnitario = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Setors", t => t.SetorId, cascadeDelete: true)
                .Index(t => t.SetorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustoCargoDiretoes", "SetorId", "dbo.Setors");
            DropIndex("dbo.CustoCargoDiretoes", new[] { "SetorId" });
            DropTable("dbo.CustoCargoDiretoes");
        }
    }
}
