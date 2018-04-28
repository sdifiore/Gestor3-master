namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aditivos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aditivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CargaId = c.Int(nullable: false),
                        InsumoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargas", t => t.CargaId, cascadeDelete: true)
                .ForeignKey("dbo.Insumoes", t => t.InsumoId, cascadeDelete: true)
                .Index(t => t.CargaId)
                .Index(t => t.InsumoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aditivoes", "InsumoId", "dbo.Insumoes");
            DropForeignKey("dbo.Aditivoes", "CargaId", "dbo.Cargas");
            DropIndex("dbo.Aditivoes", new[] { "InsumoId" });
            DropIndex("dbo.Aditivoes", new[] { "CargaId" });
            DropTable("dbo.Aditivoes");
        }
    }
}
