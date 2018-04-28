namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quadros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quadros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RlGlobalFita = c.Single(nullable: false),
                        RlGlobalTubo = c.Single(nullable: false),
                        RlGlobalFiotec = c.Single(nullable: false),
                        RlGlobalGxpuro = c.Single(nullable: false),
                        RlGlobalGxgraf = c.Single(nullable: false),
                        RlGlobalGraxa = c.Single(nullable: false),
                        RlGlobalRevenda = c.Single(nullable: false),
                        RlPropriaFita = c.Single(nullable: false),
                        RlPropriaTubo = c.Single(nullable: false),
                        RlPropriaFiotec = c.Single(nullable: false),
                        RlPropriaGxpuro = c.Single(nullable: false),
                        RlPropriaGxgraf = c.Single(nullable: false),
                        RlPropriaGraxa = c.Single(nullable: false),
                        RlPropriaRevenda = c.Single(nullable: false),
                        RlTerceirosFita = c.Single(nullable: false),
                        RlTerceirosTubo = c.Single(nullable: false),
                        RlTerceirosFiotec = c.Single(nullable: false),
                        RlTerceirosGxpuro = c.Single(nullable: false),
                        RlTerceirosGxgraf = c.Single(nullable: false),
                        RlTerceirosGraxa = c.Single(nullable: false),
                        RlTerceirosRevenda = c.Single(nullable: false),
                        PlGlobalFita = c.Single(nullable: false),
                        PlGlobalTubo = c.Single(nullable: false),
                        PlGlobalFiotec = c.Single(nullable: false),
                        PlGlobalGxpuro = c.Single(nullable: false),
                        PlGlobalGxgraf = c.Single(nullable: false),
                        PlGlobalGraxa = c.Single(nullable: false),
                        PlGlobalRevenda = c.Single(nullable: false),
                        PlPropriaFita = c.Single(nullable: false),
                        PlPropriaTubo = c.Single(nullable: false),
                        PlPropriaFiotec = c.Single(nullable: false),
                        PlPropriaGxpuro = c.Single(nullable: false),
                        PlPropriaGxgraf = c.Single(nullable: false),
                        PlPropriaGraxa = c.Single(nullable: false),
                        PlPropriaRevenda = c.Single(nullable: false),
                        PlTerceirosFita = c.Single(nullable: false),
                        PlTerceirosTubo = c.Single(nullable: false),
                        PlTerceirosFiotec = c.Single(nullable: false),
                        PlTerceirosGxpuro = c.Single(nullable: false),
                        PlTerceirosGxgraf = c.Single(nullable: false),
                        PlTerceirosGraxa = c.Single(nullable: false),
                        PlTerceirosRevenda = c.Single(nullable: false),
                        HmGlobalFita = c.Single(nullable: false),
                        HmGlobalTubo = c.Single(nullable: false),
                        HmGlobalFiotec = c.Single(nullable: false),
                        HmGlobalGxpuro = c.Single(nullable: false),
                        HmGlobalGxgraf = c.Single(nullable: false),
                        HmGlobalGraxa = c.Single(nullable: false),
                        HmGlobalRevenda = c.Single(nullable: false),
                        HmPropriaFita = c.Single(nullable: false),
                        HmPropriaTubo = c.Single(nullable: false),
                        HmPropriaFiotec = c.Single(nullable: false),
                        HmPropriaGxpuro = c.Single(nullable: false),
                        HmPropriaGxgraf = c.Single(nullable: false),
                        HmPropriaGraxa = c.Single(nullable: false),
                        HmPropriaRevenda = c.Single(nullable: false),
                        HmTerceirosFita = c.Single(nullable: false),
                        HmTerceirosTubo = c.Single(nullable: false),
                        HmTerceirosFiotec = c.Single(nullable: false),
                        HmTerceirosGxpuro = c.Single(nullable: false),
                        HmTerceirosGxgraf = c.Single(nullable: false),
                        HmTerceirosGraxa = c.Single(nullable: false),
                        HmTerceirosRevenda = c.Single(nullable: false),
                        QipGloballFita = c.Single(nullable: false),
                        QipGloballTubo = c.Single(nullable: false),
                        QipGloballFiotec = c.Single(nullable: false),
                        QipGloballGxpuro = c.Single(nullable: false),
                        QipGloballGxgraf = c.Single(nullable: false),
                        QipGloballGraxa = c.Single(nullable: false),
                        QipGloballRevenda = c.Single(nullable: false),
                        QipPropriaFita = c.Single(nullable: false),
                        QipPropriaTubo = c.Single(nullable: false),
                        QipPropriaFiotec = c.Single(nullable: false),
                        QipPropriaGxpuro = c.Single(nullable: false),
                        QipPropriaGxgraf = c.Single(nullable: false),
                        QipPropriaGraxa = c.Single(nullable: false),
                        QipPropriaRevenda = c.Single(nullable: false),
                        QipTerceirosFita = c.Single(nullable: false),
                        QipTerceirosTubo = c.Single(nullable: false),
                        QipTerceirosFiotec = c.Single(nullable: false),
                        QipTerceirosGxpuro = c.Single(nullable: false),
                        QipTerceirosGxgraf = c.Single(nullable: false),
                        QipTerceirosGraxa = c.Single(nullable: false),
                        QipTerceirosRevenda = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quadros");
        }
    }
}
