namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropParteProdutos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParteProdutoes", "DominioId", "dbo.Dominios");
            DropForeignKey("dbo.ParteProdutoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.ParteProdutoes", "PcpId", "dbo.Pcps");
            DropForeignKey("dbo.ParteProdutoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.ParteProdutoes", "TipoProducaoId", "dbo.TipoProducaos");
            DropIndex("dbo.ParteProdutoes", new[] { "GrupoRateioId" });
            DropIndex("dbo.ParteProdutoes", new[] { "DominioId" });
            DropIndex("dbo.ParteProdutoes", new[] { "TipoProducaoId" });
            DropIndex("dbo.ParteProdutoes", new[] { "PcpId" });
            DropIndex("dbo.ParteProdutoes", new[] { "ProdutoId" });
            DropTable("dbo.ParteProdutoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParteProdutoes",
                c => new
                    {
                        ParteProdutoId = c.Int(nullable: false, identity: true),
                        GrupoRateioId = c.Int(nullable: false),
                        Peso = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Ipi = c.Single(nullable: false),
                        QtdUndd = c.Int(nullable: false),
                        DominioId = c.Int(nullable: false),
                        TipoProducaoId = c.Int(nullable: false),
                        PcpId = c.Int(nullable: false),
                        QtdUndArmz = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParteProdutoId);
            
            CreateIndex("dbo.ParteProdutoes", "ProdutoId");
            CreateIndex("dbo.ParteProdutoes", "PcpId");
            CreateIndex("dbo.ParteProdutoes", "TipoProducaoId");
            CreateIndex("dbo.ParteProdutoes", "DominioId");
            CreateIndex("dbo.ParteProdutoes", "GrupoRateioId");
            AddForeignKey("dbo.ParteProdutoes", "TipoProducaoId", "dbo.TipoProducaos", "TipoProducaoId", cascadeDelete: true);
            AddForeignKey("dbo.ParteProdutoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ParteProdutoes", "PcpId", "dbo.Pcps", "PcpId", cascadeDelete: true);
            AddForeignKey("dbo.ParteProdutoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
            AddForeignKey("dbo.ParteProdutoes", "DominioId", "dbo.Dominios", "DominioId", cascadeDelete: true);
        }
    }
}
