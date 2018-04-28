namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetalheProdutoRedefined : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalheProdutoes", "GrupoRateioId", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PesoLiquido", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "Ipi", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "QtdUnid", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "DominioId", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "TipoProdId", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PcpId", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "QtUnPorUnArmz", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PesoLiquidoCalc", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "ItemStru", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CustODirTotal", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMatUltmEtapa", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMatEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMatEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstMatEtapa3", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CstTotMaterial", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CustoDirMod", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HorasModUltmEtapa", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HorasModEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HorasModEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "HorasModTotal", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CapProdHora", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "LoteMinimo", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "UsoStru", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "CustoDir", c => c.Int(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "RelModCstDir", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMatEtapaFinal", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMatEtapa1", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMatEtapa2", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "PctMatEtapa3", c => c.Single(nullable: false));
            AddColumn("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId", c => c.Int());
            CreateIndex("dbo.DetalheProdutoes", "GrupoRateioId");
            CreateIndex("dbo.DetalheProdutoes", "DominioId");
            CreateIndex("dbo.DetalheProdutoes", "PcpId");
            CreateIndex("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId");
            AddForeignKey("dbo.DetalheProdutoes", "DominioId", "dbo.Dominios", "DominioId", cascadeDelete: true);
            AddForeignKey("dbo.DetalheProdutoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
            AddForeignKey("dbo.DetalheProdutoes", "PcpId", "dbo.Pcps", "PcpId", cascadeDelete: true);
            AddForeignKey("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos", "TipoProducaoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId", "dbo.TipoProducaos");
            DropForeignKey("dbo.DetalheProdutoes", "PcpId", "dbo.Pcps");
            DropForeignKey("dbo.DetalheProdutoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.DetalheProdutoes", "DominioId", "dbo.Dominios");
            DropIndex("dbo.DetalheProdutoes", new[] { "TipoProd_TipoProducaoId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "PcpId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "DominioId" });
            DropIndex("dbo.DetalheProdutoes", new[] { "GrupoRateioId" });
            DropColumn("dbo.DetalheProdutoes", "TipoProd_TipoProducaoId");
            DropColumn("dbo.DetalheProdutoes", "PctMatEtapa3");
            DropColumn("dbo.DetalheProdutoes", "PctMatEtapa2");
            DropColumn("dbo.DetalheProdutoes", "PctMatEtapa1");
            DropColumn("dbo.DetalheProdutoes", "PctMatEtapaFinal");
            DropColumn("dbo.DetalheProdutoes", "RelModCstDir");
            DropColumn("dbo.DetalheProdutoes", "CustoDir");
            DropColumn("dbo.DetalheProdutoes", "UsoStru");
            DropColumn("dbo.DetalheProdutoes", "LoteMinimo");
            DropColumn("dbo.DetalheProdutoes", "CapProdHora");
            DropColumn("dbo.DetalheProdutoes", "HorasModTotal");
            DropColumn("dbo.DetalheProdutoes", "HorasModEtapa2");
            DropColumn("dbo.DetalheProdutoes", "HorasModEtapa1");
            DropColumn("dbo.DetalheProdutoes", "HorasModUltmEtapa");
            DropColumn("dbo.DetalheProdutoes", "CustoDirMod");
            DropColumn("dbo.DetalheProdutoes", "CstTotMaterial");
            DropColumn("dbo.DetalheProdutoes", "CstMatEtapa3");
            DropColumn("dbo.DetalheProdutoes", "CstMatEtapa2");
            DropColumn("dbo.DetalheProdutoes", "CstMatEtapa1");
            DropColumn("dbo.DetalheProdutoes", "CstMatUltmEtapa");
            DropColumn("dbo.DetalheProdutoes", "CustODirTotal");
            DropColumn("dbo.DetalheProdutoes", "ItemStru");
            DropColumn("dbo.DetalheProdutoes", "PesoLiquidoCalc");
            DropColumn("dbo.DetalheProdutoes", "QtUnPorUnArmz");
            DropColumn("dbo.DetalheProdutoes", "PcpId");
            DropColumn("dbo.DetalheProdutoes", "TipoProdId");
            DropColumn("dbo.DetalheProdutoes", "DominioId");
            DropColumn("dbo.DetalheProdutoes", "QtdUnid");
            DropColumn("dbo.DetalheProdutoes", "Ipi");
            DropColumn("dbo.DetalheProdutoes", "Ativo");
            DropColumn("dbo.DetalheProdutoes", "PesoLiquido");
            DropColumn("dbo.DetalheProdutoes", "GrupoRateioId");
        }
    }
}
