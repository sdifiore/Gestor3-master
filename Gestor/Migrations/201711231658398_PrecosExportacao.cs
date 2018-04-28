namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrecosExportacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrecoExportacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinhaUn = c.String(maxLength: 128),
                        Descricao = c.String(maxLength: 128),
                        Apelido = c.String(maxLength: 10),
                        PesoLiquido = c.Single(nullable: false),
                        QtUnid = c.Int(nullable: false),
                        De2A5 = c.Single(nullable: false),
                        De5A10 = c.Single(nullable: false),
                        De10A20 = c.Single(nullable: false),
                        Acima20 = c.Single(nullable: false),
                        Com = c.Single(nullable: false),
                        LlMin = c.Single(nullable: false),
                        CondicaoPrecoId = c.Int(nullable: false),
                        PctRateio = c.Single(nullable: false),
                        CondPag = c.Single(nullable: false),
                        IEfetiva = c.Single(nullable: false),
                        PctEspecFrete = c.Single(nullable: false),
                        DespExpPadrao = c.Boolean(nullable: false),
                        PdtDespExportEspec = c.Single(nullable: false),
                        PvFobMax = c.Single(nullable: false),
                        CustoDireto = c.Single(nullable: false),
                        RateioCustoFixo = c.Single(nullable: false),
                        PvFobMin = c.Single(nullable: false),
                        ValorCifPtfe = c.Single(nullable: false),
                        RelPtfeSobrePv = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CondicaoPrecoes", t => t.CondicaoPrecoId, cascadeDelete: true)
                .Index(t => t.CondicaoPrecoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrecoExportacaos", "CondicaoPrecoId", "dbo.CondicaoPrecoes");
            DropIndex("dbo.PrecoExportacaos", new[] { "CondicaoPrecoId" });
            DropTable("dbo.PrecoExportacaos");
        }
    }
}
