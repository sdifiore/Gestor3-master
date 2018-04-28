namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FatHistoricoDACJan2018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FatHistoricoes", "UnidAjustadaId", c => c.Int(nullable: false));
            AddColumn("dbo.FatHistoricoes", "UnidAjustada_UnidadeId", c => c.Int());
            CreateIndex("dbo.FatHistoricoes", "UnidAjustada_UnidadeId");
            AddForeignKey("dbo.FatHistoricoes", "UnidAjustada_UnidadeId", "dbo.Unidades", "UnidadeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FatHistoricoes", "UnidAjustada_UnidadeId", "dbo.Unidades");
            DropIndex("dbo.FatHistoricoes", new[] { "UnidAjustada_UnidadeId" });
            DropColumn("dbo.FatHistoricoes", "UnidAjustada_UnidadeId");
            DropColumn("dbo.FatHistoricoes", "UnidAjustadaId");
        }
    }
}
