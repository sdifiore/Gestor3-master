namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreProtubos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProcTuboes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        ResinaBaseId = c.Int(nullable: false),
                        DiamExterno = c.Single(nullable: false),
                        DiamInterno = c.Single(nullable: false),
                        SerieId = c.Int(nullable: false),
                        Carga1Id = c.Int(nullable: false),
                        PctCarga1 = c.Single(nullable: false),
                        Carga2Id = c.Int(nullable: false),
                        PctCarga2 = c.Single(nullable: false),
                        Sinterizado = c.Boolean(nullable: false),
                        CodResinaAdotada = c.Single(nullable: false),
                        RrMaxResina = c.Single(nullable: false),
                        BicoIdeal = c.Single(nullable: false),
                        MandrilIdeal = c.Single(nullable: false),
                        SecaoExtrudado = c.Single(nullable: false),
                        PerimSecaoExtrud = c.Single(nullable: false),
                        DiamExtFinalTubo = c.Single(nullable: false),
                        DiamIntFinalTubo = c.Single(nullable: false),
                        PesoUnKgMLiq = c.Single(nullable: false),
                        PtfeKgM = c.Single(nullable: false),
                        LubrKgM = c.Single(nullable: false),
                        CodPreformaIdeal = c.Int(nullable: false),
                        Rr = c.Single(nullable: false),
                        LanceSinterizado = c.Int(nullable: false),
                        FatorMultiplQtde = c.Int(nullable: false),
                        QtPf = c.Int(nullable: false),
                        EmbalagemId = c.Int(nullable: false),
                        QuantEmbalagem = c.Int(nullable: false),
                        ProcessoContinuo = c.Boolean(nullable: false),
                        VextrUmidoMin = c.Single(nullable: false),
                        FatorMultiplVExter = c.Int(nullable: false),
                        VsintMMin = c.Single(nullable: false),
                        FatorMultiplVelSint = c.Single(nullable: false),
                        VSintResultante = c.Single(nullable: false),
                        TesteEstqEsto = c.Boolean(nullable: false),
                        ConfAdtDosLub = c.Single(nullable: false),
                        Peneiramento = c.Single(nullable: false),
                        MisturaMinM = c.Single(nullable: false),
                        PreparoExtrusMinM = c.Single(nullable: false),
                        VelEfetExtrusaoMMin = c.Single(nullable: false),
                        TuSinterizadoMinM = c.Single(nullable: false),
                        TuProducaoMinM = c.Single(nullable: false),
                        TuInspUdc3MinM = c.Single(nullable: false),
                        TuTesteEstanqMinM = c.Single(nullable: false),
                        TuTesteEstouroMinM = c.Single(nullable: false),
                        TuEmbalMinM = c.Single(nullable: false),
                        TuTotalMinM = c.Single(nullable: false),
                        CustoPtfeRsM = c.Single(nullable: false),
                        CustoAditivosRsM = c.Single(nullable: false),
                        CustoLubrifRsM = c.Single(nullable: false),
                        CustoEmbalRsM = c.Single(nullable: false),
                        CustoModRsM = c.Single(nullable: false),
                        CustoDiretoTotalRsM = c.Single(nullable: false),
                        CustoIndiretoRsM = c.Single(nullable: false),
                        CustoTotalRsM = c.Single(nullable: false),
                        PvRsKg = c.Single(nullable: false),
                        CapProducaoMH = c.Single(nullable: false),
                        QtPCusto = c.Single(nullable: false),
                        PvCalculadoRsM = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargas", t => t.Carga1Id, cascadeDelete: true)
                .ForeignKey("dbo.Cargas", t => t.Carga2Id, cascadeDelete: false)
                .ForeignKey("dbo.Embals", t => t.EmbalagemId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: false)
                .ForeignKey("dbo.ResinaBases", t => t.ResinaBaseId, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.SerieId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.ResinaBaseId)
                .Index(t => t.SerieId)
                .Index(t => t.Carga1Id)
                .Index(t => t.Carga2Id)
                .Index(t => t.EmbalagemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProcTuboes", "SerieId", "dbo.Series");
            DropForeignKey("dbo.ProcTuboes", "ResinaBaseId", "dbo.ResinaBases");
            DropForeignKey("dbo.ProcTuboes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.ProcTuboes", "EmbalagemId", "dbo.Embals");
            DropForeignKey("dbo.ProcTuboes", "Carga2Id", "dbo.Cargas");
            DropForeignKey("dbo.ProcTuboes", "Carga1Id", "dbo.Cargas");
            DropIndex("dbo.ProcTuboes", new[] { "EmbalagemId" });
            DropIndex("dbo.ProcTuboes", new[] { "Carga2Id" });
            DropIndex("dbo.ProcTuboes", new[] { "Carga1Id" });
            DropIndex("dbo.ProcTuboes", new[] { "SerieId" });
            DropIndex("dbo.ProcTuboes", new[] { "ResinaBaseId" });
            DropIndex("dbo.ProcTuboes", new[] { "ProdutoId" });
            DropTable("dbo.ProcTuboes");
        }
    }
}
