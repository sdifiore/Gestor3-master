namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResizeProdutoesToOnlyGreenFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.Produtoes", new[] { "GrupoRateioId" });
            AddColumn("dbo.Produtoes", "FlagProduto", c => c.Boolean(nullable: false));
            DropColumn("dbo.Produtoes", "GrupoRateioId");
            DropColumn("dbo.Produtoes", "QuantidadeCusto");
            DropColumn("dbo.Produtoes", "PesoBruto");
            DropColumn("dbo.Produtoes", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produtoes", "PesoBruto", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "QuantidadeCusto", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "GrupoRateioId", c => c.Int(nullable: false));
            DropColumn("dbo.Produtoes", "FlagProduto");
            CreateIndex("dbo.Produtoes", "GrupoRateioId");
            AddForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
        }
    }
}
