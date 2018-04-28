namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QtdEmbalagems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QtdEmbalagems",
                c => new
                    {
                        QtdEmbalagemId = c.Int(nullable: false, identity: true),
                        CartuchoRolCx = c.Int(nullable: false),
                        CartuchoCxPlt = c.Int(nullable: false),
                        DisplayRolCx = c.Int(),
                        CarretelRolCx = c.Int(nullable: false),
                        CarretelCxPlt = c.Int(nullable: false),
                        MedidaFitasId = c.Int(nullable: false),
                        MedidaFita_MedidaFitaId = c.Int(),
                    })
                .PrimaryKey(t => t.QtdEmbalagemId)
                .ForeignKey("dbo.MedidaFitas", t => t.MedidaFita_MedidaFitaId)
                .Index(t => t.MedidaFita_MedidaFitaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QtdEmbalagems", "MedidaFita_MedidaFitaId", "dbo.MedidaFitas");
            DropIndex("dbo.QtdEmbalagems", new[] { "MedidaFita_MedidaFitaId" });
            DropTable("dbo.QtdEmbalagems");
        }
    }
}
