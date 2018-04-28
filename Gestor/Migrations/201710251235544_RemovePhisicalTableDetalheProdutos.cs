namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhisicalTableDetalheProdutos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalheProdutoes", "DominioId", "dbo.Dominios");
            DropForeignKey("dbo.DetalheProdutoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.DetalheProdutoes", "PcpId", "dbo.Pcps");
            DropForeignKey("dbo.DetalheProdutoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos");
            DropIndex("dbo.DetalheProdutoes", new[] { "GrupoRateioId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "DominioId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "PcpId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "ProdutoId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "TipoProd_TipoProducaoId" });
            DropTable("dbo.DetalheProdutoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DetalheProdutoes",
                c => new
                    {
                        DetalheProdutoId = c.Int(nullable: false, identity: true),
                        GrupoRateioId = c.Int(nullable: false),
                        PesoLiquido = c.Single(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Ipi = c.Single(nullable: false),
                        QtdUnid = c.Int(nullable: false),
                        DominioId = c.Int(nullable: false),
                        TipoProdId = c.Int(nullable: false),
                        PcpId = c.Int(nullable: false),
                        QtUnPorUnArmz = c.Int(nullable: false),
                        PesoLiquidoCalc = c.Single(nullable: false),
                        ItemStru = c.Int(nullable: false),
                        CustODirTotal = c.Single(nullable: false),
                        CstMatUltmEtapa = c.Single(nullable: false),
                        CstMatEtapa1 = c.Single(nullable: false),
                        CstMatEtapa2 = c.Single(nullable: false),
                        CstMatEtapa3 = c.Single(nullable: false),
                        CstTotMaterial = c.Single(nullable: false),
                        CustoDirMod = c.Single(nullable: false),
                        HorasModUltmEtapa = c.Single(nullable: false),
                        HorasModEtapa1 = c.Single(nullable: false),
                        HorasModEtapa2 = c.Single(nullable: false),
                        HorasModTotal = c.Single(nullable: false),
                        CapProdHora = c.Single(nullable: false),
                        LoteMinimo = c.Int(nullable: false),
                        UsoStru = c.Int(nullable: false),
                        CustoDir = c.Int(nullable: false),
                        RelModCstDir = c.Single(nullable: false),
                        PctMatEtapaFinal = c.Single(nullable: false),
                        PctMatEtapa1 = c.Single(nullable: false),
                        PctMatEtapa2 = c.Single(nullable: false),
                        PctMatEtapa3 = c.Single(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        TipoProd_TipoProducaoId = c.Int(),
                    })
                .PrimaryKey(t => t.DetalheProdutoId);
            
            CreateIndex("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId");
            CreateIndex("dbo.DetalheProdutoes", "ProdutoId");
            CreateIndex("dbo.DetalheProdutoes", "PcpId");
            CreateIndex("dbo.DetalheProdutoes", "DominioId");
            CreateIndex("dbo.DetalheProdutoes", "GrupoRateioId");
            AddForeignKey("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos", "TipoProducaoId");
            AddForeignKey("dbo.DetalheProdutoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetalheProdutoes", "PcpId", "dbo.Pcps", "PcpId", cascadeDelete: true);
            AddForeignKey("dbo.DetalheProdutoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
            AddForeignKey("dbo.DetalheProdutoes", "DominioId", "dbo.Dominios", "DominioId", cascadeDelete: true);
        }
    }
}
