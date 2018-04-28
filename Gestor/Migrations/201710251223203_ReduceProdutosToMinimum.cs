namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReduceProdutosToMinimum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "DominioId", "dbo.Dominios");
            DropForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.Produtoes", "PcpId", "dbo.Pcps");
            DropForeignKey("dbo.Produtoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos");
            DropForeignKey("dbo.DetalheProdutoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Produtoes", new[] { "GrupoRateioId" });
            DropIndex("dbo.Produtoes", new[] { "DominioId" });
            DropIndex("dbo.Produtoes", new[] { "PcpId" });
            DropIndex("dbo.Produtoes", new[] { "TipoProd_TipoProducaoId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "ProdutoId" });
            DropColumn("dbo.Produtoes", "GrupoRateioId");
            DropColumn("dbo.Produtoes", "PesoLiquido");
            DropColumn("dbo.Produtoes", "Ativo");
            DropColumn("dbo.Produtoes", "Ipi");
            DropColumn("dbo.Produtoes", "QtdUnid");
            DropColumn("dbo.Produtoes", "DominioId");
            DropColumn("dbo.Produtoes", "TipoProdId");
            DropColumn("dbo.Produtoes", "PcpId");
            DropColumn("dbo.Produtoes", "QtUnPorUnArmz");
            DropColumn("dbo.Produtoes", "PesoLiquidoCalc");
            DropColumn("dbo.Produtoes", "ItemStru");
            DropColumn("dbo.Produtoes", "CustODirTotal");
            DropColumn("dbo.Produtoes", "CstMatUltmEtapa");
            DropColumn("dbo.Produtoes", "CstMatEtapa1");
            DropColumn("dbo.Produtoes", "CstMatEtapa2");
            DropColumn("dbo.Produtoes", "CstMatEtapa3");
            DropColumn("dbo.Produtoes", "CstTotMaterial");
            DropColumn("dbo.Produtoes", "CustoDirMod");
            DropColumn("dbo.Produtoes", "HorasModUltmEtapa");
            DropColumn("dbo.Produtoes", "HorasModEtapa1");
            DropColumn("dbo.Produtoes", "HorasModEtapa2");
            DropColumn("dbo.Produtoes", "HorasModTotal");
            DropColumn("dbo.Produtoes", "CapProdHora");
            DropColumn("dbo.Produtoes", "LoteMinimo");
            DropColumn("dbo.Produtoes", "UsoStru");
            DropColumn("dbo.Produtoes", "CustoDir");
            DropColumn("dbo.Produtoes", "RelModCstDir");
            DropColumn("dbo.Produtoes", "PctMatEtapaFinal");
            DropColumn("dbo.Produtoes", "PctMatEtapa1");
            DropColumn("dbo.Produtoes", "PctMatEtapa2");
            DropColumn("dbo.Produtoes", "PctMatEtapa3");
            DropColumn("dbo.Produtoes", "TipoProd_TipoProducaoId");
            DropColumn("dbo.DetalheProdutoes", "PesoLiquido");
            DropColumn("dbo.DetalheProdutoes", "ItemStrut");
            DropColumn("dbo.DetalheProdutoes", "CstDirIndd");
            DropColumn("dbo.DetalheProdutoes", "CstMtsUltmEtp");
            DropColumn("dbo.DetalheProdutoes", "CstMtsEtp1");
            DropColumn("dbo.DetalheProdutoes", "CstMtsEtp2");
            DropColumn("dbo.DetalheProdutoes", "CstMtsEtp3");
            DropColumn("dbo.DetalheProdutoes", "CstTotMts");
            DropColumn("dbo.DetalheProdutoes", "CstDirMod");
            DropColumn("dbo.DetalheProdutoes", "HrsMod");
            DropColumn("dbo.DetalheProdutoes", "HrsMod1");
            DropColumn("dbo.DetalheProdutoes", "HrsMod2");
            DropColumn("dbo.DetalheProdutoes", "HrsTotMod");
            DropColumn("dbo.DetalheProdutoes", "CpcdProdHrr");
            DropColumn("dbo.DetalheProdutoes", "LoteMin");
            DropColumn("dbo.DetalheProdutoes", "UsoStrut");
            DropColumn("dbo.DetalheProdutoes", "CstDirRgKg");
            DropColumn("dbo.DetalheProdutoes", "RelModCst");
            DropColumn("dbo.DetalheProdutoes", "PctMtrFnl");
            DropColumn("dbo.DetalheProdutoes", "PctMtrEtp1");
            DropColumn("dbo.DetalheProdutoes", "PctMtrEtp2");
            DropColumn("dbo.DetalheProdutoes", "PctMtrEtp3");
            DropColumn("dbo.DetalheProdutoes", "ProdutoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalheProdutoes", "ProdutoId", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMtrEtp3", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMtrEtp2", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMtrEtp1", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMtrFnl", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "RelModCst", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstDirRgKg", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "UsoStrut", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "LoteMin", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CpcdProdHrr", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HrsTotMod", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HrsMod2", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HrsMod1", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HrsMod", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstDirMod", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstTotMts", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMtsEtp3", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMtsEtp2", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMtsEtp1", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMtsUltmEtp", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstDirIndd", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "ItemStrut", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PesoLiquido", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "TipoProd_TipoProducaoId", c => c.Int());
            AddColumn("dbo.Produtoes", "PctMatEtapa3", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "PctMatEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "PctMatEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "PctMatEtapaFinal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "RelModCstDir", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustoDir", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "UsoStru", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "LoteMinimo", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "CapProdHora", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModUltmEtapa", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustoDirMod", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstTotMaterial", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatEtapa3", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatUltmEtapa", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustODirTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "ItemStru", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "PesoLiquidoCalc", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "QtUnPorUnArmz", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "PcpId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "TipoProdId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "DominioId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "QtdUnid", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "Ipi", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produtoes", "PesoLiquido", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "GrupoRateioId", c => c.Int(nullable: false));
            CreateIndex("dbo.DetalheProdutoes", "ProdutoId");
            CreateIndex("dbo.Produtoes", "TipoProd_TipoProducaoId");
            CreateIndex("dbo.Produtoes", "PcpId");
            CreateIndex("dbo.Produtoes", "DominioId");
            CreateIndex("dbo.Produtoes", "GrupoRateioId");
            AddForeignKey("dbo.DetalheProdutoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos", "TipoProducaoId");
            AddForeignKey("dbo.Produtoes", "PcpId", "dbo.Pcps", "PcpId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "DominioId", "dbo.Dominios", "DominioId", cascadeDelete: true);
        }
    }
}
