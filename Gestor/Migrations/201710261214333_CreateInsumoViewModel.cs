namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInsumoViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsumoViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comum_ComumId = c.Int(),
                        Insumo_InsumoId = c.Int(),
                        InsumoXtd_InsuMoXtdId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comums", t => t.Comum_ComumId)
                .ForeignKey("dbo.Insumoes", t => t.Insumo_InsumoId)
                .ForeignKey("dbo.InsumoXtds", t => t.InsumoXtd_InsuMoXtdId)
                .Index(t => t.Comum_ComumId)
                .Index(t => t.Insumo_InsumoId)
                .Index(t => t.InsumoXtd_InsuMoXtdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsumoViewModels", "InsumoXtd_InsuMoXtdId", "dbo.InsumoXtds");
            DropForeignKey("dbo.InsumoViewModels", "Insumo_InsumoId", "dbo.Insumoes");
            DropForeignKey("dbo.InsumoViewModels", "Comum_ComumId", "dbo.Comums");
            DropIndex("dbo.InsumoViewModels", new[] { "InsumoXtd_InsuMoXtdId" });
            DropIndex("dbo.InsumoViewModels", new[] { "Insumo_InsumoId" });
            DropIndex("dbo.InsumoViewModels", new[] { "Comum_ComumId" });
            DropTable("dbo.InsumoViewModels");
        }
    }
}
