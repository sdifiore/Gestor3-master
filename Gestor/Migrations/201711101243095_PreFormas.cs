namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreFormas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreFormas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreFormaNum = c.Int(nullable: false),
                        FormaDiamE = c.Int(nullable: false),
                        VaretaDiamI = c.Int(nullable: false),
                        MedidaFitaId = c.Int(nullable: false),
                        Comprimento = c.Int(nullable: false),
                        Tup = c.Int(nullable: false),
                        PrensaPreFormaId = c.Int(nullable: false),
                        Preparo = c.Int(nullable: false),
                        TrocaPf = c.Int(nullable: false),
                        ExtrusoraId = c.Int(nullable: false),
                        SecaoPf = c.Single(nullable: false),
                        KgfPrensagem = c.Single(nullable: false),
                        PressaoOleo = c.Single(nullable: false),
                        DiamPistaoHidraulico = c.Single(nullable: false),
                        KgPfUmida = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Extrusoras", t => t.ExtrusoraId, cascadeDelete: true)
                .ForeignKey("dbo.MedidaFitas", t => t.MedidaFitaId, cascadeDelete: true)
                .ForeignKey("dbo.PrensaPreFormas", t => t.PrensaPreFormaId, cascadeDelete: true)
                .Index(t => t.MedidaFitaId)
                .Index(t => t.PrensaPreFormaId)
                .Index(t => t.ExtrusoraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreFormas", "PrensaPreFormaId", "dbo.PrensaPreFormas");
            DropForeignKey("dbo.PreFormas", "MedidaFitaId", "dbo.MedidaFitas");
            DropForeignKey("dbo.PreFormas", "ExtrusoraId", "dbo.Extrusoras");
            DropIndex("dbo.PreFormas", new[] { "ExtrusoraId" });
            DropIndex("dbo.PreFormas", new[] { "PrensaPreFormaId" });
            DropIndex("dbo.PreFormas", new[] { "MedidaFitaId" });
            DropTable("dbo.PreFormas");
        }
    }
}
