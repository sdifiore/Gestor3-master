namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DespsFixas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DespFixas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Historico = c.String(maxLength: 128),
                        ValorTotal = c.Single(nullable: false),
                        Comentario = c.String(maxLength: 1024),
                        CodCrit = c.String(maxLength: 3),
                        CriterioRateio = c.String(maxLength: 32),
                        Fita = c.Single(nullable: false),
                        Tubo = c.Single(nullable: false),
                        Fiotec = c.Single(nullable: false),
                        Gxpuro = c.Single(nullable: false),
                        Gxgraf = c.Single(nullable: false),
                        Graxa = c.Single(nullable: false),
                        Revenda = c.Single(nullable: false),
                        Somas = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DespFixas");
        }
    }
}
