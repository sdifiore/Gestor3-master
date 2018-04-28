namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkGrupoRateioToProdutoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "GrupoRateioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "GrupoRateioId");
            AddForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.Produtoes", new[] { "GrupoRateioId" });
            DropColumn("dbo.Produtoes", "GrupoRateioId");
        }
    }
}
