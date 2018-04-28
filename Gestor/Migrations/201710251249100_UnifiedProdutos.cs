namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnifiedProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "GrupoRateioId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "PesoLiquido", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produtoes", "Ipi", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "QtdUnid", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "DominioId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "TipoProdId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "PcpId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "QtUnPorUnArmz", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "PesoLiquidoCalc", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "ItemStru", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "CustODirTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatUltmEtapa", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstMatEtapa3", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstTotMaterial", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CustoDirMod", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModUltmEtapa", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "HorasModTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CapProdHora", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "LoteMinimo", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "UsoStru", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "CustoDir", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "RelModCstDir", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "PctMatEtapaFinal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "PctMatEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "PctMatEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "PctMatEtapa3", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "TipoProd_TipoProducaoId", c => c.Int());
            CreateIndex("dbo.Produtoes", "GrupoRateioId");
            CreateIndex("dbo.Produtoes", "DominioId");
            CreateIndex("dbo.Produtoes", "PcpId");
            CreateIndex("dbo.Produtoes", "TipoProd_TipoProducaoId");
            AddForeignKey("dbo.Produtoes", "DominioId", "dbo.Dominios", "DominioId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "PcpId", "dbo.Pcps", "PcpId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos", "TipoProducaoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos");
            DropForeignKey("dbo.Produtoes", "PcpId", "dbo.Pcps");
            DropForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.Produtoes", "DominioId", "dbo.Dominios");
            DropIndex("dbo.Produtoes", new[] { "TipoProd_TipoProducaoId" });
            DropIndex("dbo.Produtoes", new[] { "PcpId" });
            DropIndex("dbo.Produtoes", new[] { "DominioId" });
            DropIndex("dbo.Produtoes", new[] { "GrupoRateioId" });
            DropColumn("dbo.Produtoes", "TipoProd_TipoProducaoId");
            DropColumn("dbo.Produtoes", "PctMatEtapa3");
            DropColumn("dbo.Produtoes", "PctMatEtapa2");
            DropColumn("dbo.Produtoes", "PctMatEtapa1");
            DropColumn("dbo.Produtoes", "PctMatEtapaFinal");
            DropColumn("dbo.Produtoes", "RelModCstDir");
            DropColumn("dbo.Produtoes", "CustoDir");
            DropColumn("dbo.Produtoes", "UsoStru");
            DropColumn("dbo.Produtoes", "LoteMinimo");
            DropColumn("dbo.Produtoes", "CapProdHora");
            DropColumn("dbo.Produtoes", "HorasModTotal");
            DropColumn("dbo.Produtoes", "HorasModEtapa2");
            DropColumn("dbo.Produtoes", "HorasModEtapa1");
            DropColumn("dbo.Produtoes", "HorasModUltmEtapa");
            DropColumn("dbo.Produtoes", "CustoDirMod");
            DropColumn("dbo.Produtoes", "CstTotMaterial");
            DropColumn("dbo.Produtoes", "CstMatEtapa3");
            DropColumn("dbo.Produtoes", "CstMatEtapa2");
            DropColumn("dbo.Produtoes", "CstMatEtapa1");
            DropColumn("dbo.Produtoes", "CstMatUltmEtapa");
            DropColumn("dbo.Produtoes", "CustODirTotal");
            DropColumn("dbo.Produtoes", "ItemStru");
            DropColumn("dbo.Produtoes", "PesoLiquidoCalc");
            DropColumn("dbo.Produtoes", "QtUnPorUnArmz");
            DropColumn("dbo.Produtoes", "PcpId");
            DropColumn("dbo.Produtoes", "TipoProdId");
            DropColumn("dbo.Produtoes", "DominioId");
            DropColumn("dbo.Produtoes", "QtdUnid");
            DropColumn("dbo.Produtoes", "Ipi");
            DropColumn("dbo.Produtoes", "Ativo");
            DropColumn("dbo.Produtoes", "PesoLiquido");
            DropColumn("dbo.Produtoes", "GrupoRateioId");
        }
    }
}
