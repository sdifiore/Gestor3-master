namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAreaFitas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaFitas",
                c => new
                    {
                        AreaFitaId = c.Int(nullable: false, identity: true),
                        RoloM2 = c.Single(nullable: false),
                        MrmM2 = c.Single(nullable: false),
                        MraM2 = c.Single(nullable: false),
                        MedidaFitaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaFitaId)
                .ForeignKey("dbo.MedidaFitas", t => t.MedidaFitaId, cascadeDelete: true)
                .Index(t => t.MedidaFitaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AreaFitas", "MedidaFitaId", "dbo.MedidaFitas");
            DropIndex("dbo.AreaFitas", new[] { "MedidaFitaId" });
            DropTable("dbo.AreaFitas");
        }
    }
}
