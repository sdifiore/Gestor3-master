namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGrupoRateioToRateioInCuboTrabalhado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CubosTrabalhados", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.CubosTrabalhados", new[] { "GrupoRateioId" });
            AddColumn("dbo.CubosTrabalhados", "GrupoRateio_RateioId", c => c.Int());
            CreateIndex("dbo.CubosTrabalhados", "GrupoRateio_RateioId");
            AddForeignKey("dbo.CubosTrabalhados", "GrupoRateio_RateioId", "dbo.Rateios", "RateioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CubosTrabalhados", "GrupoRateio_RateioId", "dbo.Rateios");
            DropIndex("dbo.CubosTrabalhados", new[] { "GrupoRateio_RateioId" });
            DropColumn("dbo.CubosTrabalhados", "GrupoRateio_RateioId");
            CreateIndex("dbo.CubosTrabalhados", "GrupoRateioId");
            AddForeignKey("dbo.CubosTrabalhados", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
        }
    }
}
