namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEmbalagens : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Graxas", "EmbalagemId", "dbo.Embalagems");
            DropForeignKey("dbo.Graxas", "ResinaId", "dbo.Resinas");
            DropForeignKey("dbo.ProcTuboes", "Carga1Id", "dbo.Cargas");
            DropForeignKey("dbo.ProcTuboes", "Carga2Id", "dbo.Cargas");
            DropForeignKey("dbo.ProcTuboes", "EmbalagemId", "dbo.Embals");
            DropForeignKey("dbo.ProcTuboes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.ProcTuboes", "ResinaBaseId", "dbo.ResinaBases");
            DropForeignKey("dbo.ProcTuboes", "SerieId", "dbo.Series");
            DropIndex("dbo.Graxas", new[] { "EmbalagemId" });
            DropIndex("dbo.Graxas", new[] { "ResinaId" });
            DropIndex("dbo.ProcTuboes", new[] { "ProdutoId" });
            DropIndex("dbo.ProcTuboes", new[] { "ResinaBaseId" });
            DropIndex("dbo.ProcTuboes", new[] { "SerieId" });
            DropIndex("dbo.ProcTuboes", new[] { "Carga1Id" });
            DropIndex("dbo.ProcTuboes", new[] { "Carga2Id" });
            DropIndex("dbo.ProcTuboes", new[] { "EmbalagemId" });
            
            DropTable("dbo.Graxas");
            DropTable("dbo.ProcTuboes");
            DropTable("dbo.Embalagems");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Graxas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        EmbalagemId = c.Int(nullable: false),
                        Peso = c.Single(nullable: false),
                        PctSilicone = c.Single(nullable: false),
                        PctSilica = c.Single(nullable: false),
                        PctPtfe = c.Single(nullable: false),
                        ResinaId = c.Int(nullable: false),
                        PesagemMinUn = c.Single(nullable: false),
                        Mistura = c.Single(nullable: false),
                        EmbalagemMedida = c.Single(nullable: false),
                        Rotulagem = c.Single(nullable: false),
                        LoteMinino = c.Single(nullable: false),
                        Ptfe = c.Single(nullable: false),
                        Silicone = c.Single(nullable: false),
                        Silica = c.Single(nullable: false),
                        PesagemH = c.Single(nullable: false),
                        MisturaH = c.Single(nullable: false),
                        EmbalarH = c.Single(nullable: false),
                        RotularH = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Embalagems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProcTuboes", "EmbalagemId");
            CreateIndex("dbo.ProcTuboes", "Carga2Id");
            CreateIndex("dbo.ProcTuboes", "Carga1Id");
            CreateIndex("dbo.ProcTuboes", "SerieId");
            CreateIndex("dbo.ProcTuboes", "ResinaBaseId");
            CreateIndex("dbo.ProcTuboes", "ProdutoId");
            CreateIndex("dbo.Graxas", "ResinaId");
            CreateIndex("dbo.Graxas", "EmbalagemId");
            AddForeignKey("dbo.ProcTuboes", "SerieId", "dbo.Series", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcTuboes", "ResinaBaseId", "dbo.ResinaBases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcTuboes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcTuboes", "EmbalagemId", "dbo.Embals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcTuboes", "Carga2Id", "dbo.Cargas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProcTuboes", "Carga1Id", "dbo.Cargas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Graxas", "ResinaId", "dbo.Resinas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Graxas", "EmbalagemId", "dbo.Embalagems", "Id", cascadeDelete: true);
        }
    }
}
