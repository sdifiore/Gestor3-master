namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterKeyInIndiceRateioFormacaoPrecoVendaTableToRateio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.IndiceRateioFormacaoPrecoVendas", new[] { "GrupoRateioId" });
            AddColumn("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateio_RateioId", c => c.Int());
            CreateIndex("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateio_RateioId");
            AddForeignKey("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateio_RateioId", "dbo.Rateios", "RateioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateio_RateioId", "dbo.Rateios");
            DropIndex("dbo.IndiceRateioFormacaoPrecoVendas", new[] { "GrupoRateio_RateioId" });
            DropColumn("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateio_RateioId");
            CreateIndex("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId");
            AddForeignKey("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
        }
    }
}
