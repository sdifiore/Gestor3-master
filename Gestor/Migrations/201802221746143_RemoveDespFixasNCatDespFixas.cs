namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDespFixasNCatDespFixas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DespFixas", "CatDespFixaId", "dbo.CatDespFixas");
            DropIndex("dbo.DespFixas", new[] { "CatDespFixaId" });
            AddColumn("dbo.DespesaFixas", "RateioFiotec", c => c.Single(nullable: false));
            DropTable("dbo.CatDespFixas");
            DropTable("dbo.DespFixas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DespFixas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatDespFixaId = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.CatDespFixas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categoria = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.DespesaFixas", "RateioFiotec");
            CreateIndex("dbo.DespFixas", "CatDespFixaId");
            AddForeignKey("dbo.DespFixas", "CatDespFixaId", "dbo.CatDespFixas", "Id", cascadeDelete: true);
        }
    }
}
