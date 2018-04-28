namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedidaFitas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedidaFitas",
                c => new
                    {
                        MedidaFitaId = c.Int(nullable: false, identity: true),
                        LarguraMm = c.Int(nullable: false),
                        ComprimentoMetros = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedidaFitaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MedidaFitas");
        }
    }
}
