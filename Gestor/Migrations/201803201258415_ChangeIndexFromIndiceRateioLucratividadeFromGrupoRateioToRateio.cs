namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIndexFromIndiceRateioLucratividadeFromGrupoRateioToRateio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndiceRateioLucratividades", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.IndiceRateioLucratividades", new[] { "GrupoRateioId" });
            AddColumn("dbo.DespesaFixas", "RateioSucatas", c => c.Single(nullable: false));
            AddColumn("dbo.IndiceRateioLucratividades", "GrupoRateio_RateioId", c => c.Int());
            CreateIndex("dbo.IndiceRateioLucratividades", "GrupoRateio_RateioId");
            AddForeignKey("dbo.IndiceRateioLucratividades", "GrupoRateio_RateioId", "dbo.Rateios", "RateioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndiceRateioLucratividades", "GrupoRateio_RateioId", "dbo.Rateios");
            DropIndex("dbo.IndiceRateioLucratividades", new[] { "GrupoRateio_RateioId" });
            DropColumn("dbo.IndiceRateioLucratividades", "GrupoRateio_RateioId");
            DropColumn("dbo.DespesaFixas", "RateioSucatas");
            CreateIndex("dbo.IndiceRateioLucratividades", "GrupoRateioId");
            AddForeignKey("dbo.IndiceRateioLucratividades", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
        }
    }
}
