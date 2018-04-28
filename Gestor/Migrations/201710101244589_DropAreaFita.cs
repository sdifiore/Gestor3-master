namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAreaFita : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AreaFitas", "MedidaFitaId", "dbo.MedidaFitas");
            DropIndex("dbo.AreaFitas", new[] { "MedidaFitaId" });
            DropTable("dbo.AreaFitas");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.AreaFitaId);
            
            CreateIndex("dbo.AreaFitas", "MedidaFitaId");
            AddForeignKey("dbo.AreaFitas", "MedidaFitaId", "dbo.MedidaFitas", "MedidaFitaId", cascadeDelete: true);
        }
    }
}
