namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstPartFatHistoricos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FatHistoricoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        PesoUnitario = c.Single(nullable: false),
                        HorasMod = c.Single(nullable: false),
                        CustoDiretoTotal = c.Single(nullable: false),
                        CustoDiretoMats = c.Single(nullable: false),
                        CustoDiretoMod = c.Single(nullable: false),
                        CustoFixoFabrica = c.Single(nullable: false),
                        CustoFixAdmCom = c.Single(nullable: false),
                        AliquotaIpi = c.Single(nullable: false),
                        QtNacAnoMenos12 = c.Single(nullable: false),
                        QtNacAnoMenos11 = c.Single(nullable: false),
                        QtNacAnoMenos10 = c.Single(nullable: false),
                        QtNacAnoMenos9 = c.Single(nullable: false),
                        QtNacAnoMenos8 = c.Single(nullable: false),
                        QtNacAnoMenos7 = c.Single(nullable: false),
                        QtNacAnoMenos6 = c.Single(nullable: false),
                        QtNacAnoMenos5 = c.Single(nullable: false),
                        QtNacAnoMenos4 = c.Single(nullable: false),
                        QtNacAnoMenos3 = c.Single(nullable: false),
                        QtNacAnoMenos2 = c.Single(nullable: false),
                        QtNacAno = c.Single(nullable: false),
                        QtNacMediaMensal = c.Single(nullable: false),
                        PvMed1o3m = c.Single(nullable: false),
                        PvMed2o3m = c.Single(nullable: false),
                        PvMed3o3m = c.Single(nullable: false),
                        PvMed4o3m = c.Single(nullable: false),
                        PvNacAdotado = c.Single(nullable: false),
                        StMedia = c.Single(nullable: false),
                        IcmsMedio = c.Single(nullable: false),
                        ComissaoMediaNac = c.Single(nullable: false),
                        FreteNacPct = c.Single(nullable: false),
                        MesRecebMedNac = c.Int(nullable: false),
                        QtExpAnoMenos12 = c.Single(nullable: false),
                        QtExpAnoMenos11 = c.Single(nullable: false),
                        QtExpAnoMenos10 = c.Single(nullable: false),
                        QtExpAnoMenos9 = c.Single(nullable: false),
                        QtExpAnoMenos8 = c.Single(nullable: false),
                        QtExpAnoMenos7 = c.Single(nullable: false),
                        QtExpAnoMenos6 = c.Single(nullable: false),
                        QtExpAnoMenos5 = c.Single(nullable: false),
                        QtExpAnoMenos4 = c.Single(nullable: false),
                        QtExpAnoMenos3 = c.Single(nullable: false),
                        QtExpAnoMenos2 = c.Single(nullable: false),
                        QtExpAno = c.Single(nullable: false),
                        QtExpMediaMensal = c.Single(nullable: false),
                        PvMedEx1o3m = c.Single(nullable: false),
                        PvMedEx2o3m = c.Single(nullable: false),
                        PvMedEx3o3m = c.Single(nullable: false),
                        PvMedEx4o3m = c.Single(nullable: false),
                        PvMedExAdotado = c.Single(nullable: false),
                        ComissaoExpPct = c.Single(nullable: false),
                        PrazoRecebMedExp = c.Int(nullable: false),
                        ComentarioCelulaBi = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FatHistoricoes");
        }
    }
}
