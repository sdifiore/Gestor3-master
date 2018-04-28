namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMedidasInPreFormaToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PreFormas", "MedidaFitaId", "dbo.MedidaFitas");
            DropIndex("dbo.PreFormas", new[] { "MedidaFitaId" });
            AddColumn("dbo.PreFormas", "Medidas", c => c.String(maxLength: 8));
            DropColumn("dbo.PreFormas", "MedidaFitaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PreFormas", "MedidaFitaId", c => c.Int(nullable: false));
            DropColumn("dbo.PreFormas", "Medidas");
            CreateIndex("dbo.PreFormas", "MedidaFitaId");
            AddForeignKey("dbo.PreFormas", "MedidaFitaId", "dbo.MedidaFitas", "MedidaFitaId", cascadeDelete: true);
        }
    }
}
