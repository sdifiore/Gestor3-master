namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropFaturamentoHistorico : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FatHistoricoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FatHistoricoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rotulo = c.String(maxLength: 10),
                        FitaRecLiq = c.Single(nullable: false),
                        FitaPeso = c.Single(nullable: false),
                        FitaHora = c.Single(nullable: false),
                        TuboRecLiq = c.Single(nullable: false),
                        TuboPeso = c.Single(nullable: false),
                        TuboHora = c.Single(nullable: false),
                        GxfPuroRecLiq = c.Single(nullable: false),
                        GxfPuroPeso = c.Single(nullable: false),
                        GxfPuroHora = c.Single(nullable: false),
                        GxfGrafRecLiq = c.Single(nullable: false),
                        GxfGrafPeso = c.Single(nullable: false),
                        GxfGrafHora = c.Single(nullable: false),
                        GraxaRecLiq = c.Single(nullable: false),
                        GraxaPeso = c.Single(nullable: false),
                        GraxaHora = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
