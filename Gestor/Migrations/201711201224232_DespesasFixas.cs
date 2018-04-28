namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DespesasFixas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DespesaFixas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Despesa = c.String(maxLength: 128),
                        ValorTotal = c.Single(nullable: false),
                        CodCrit = c.Int(nullable: false),
                        CriterioRateio = c.String(maxLength: 128),
                        RateioFitas = c.Single(nullable: false),
                        RateioTuboCordaoPerfil = c.Single(nullable: false),
                        RateioFioGaxPtfePuro = c.Single(nullable: false),
                        RateioFioGaxPtfeGraf = c.Single(nullable: false),
                        RateioGraxa = c.Single(nullable: false),
                        RateioSucatas = c.Single(nullable: false),
                        RateioRevenda = c.Single(nullable: false),
                        Somas = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DespesaFixas");
        }
    }
}
