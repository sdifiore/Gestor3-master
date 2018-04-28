namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndiceRateioLucratividade1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndiceRateioLucratividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupoRateioId = c.Int(nullable: false),
                        TotalCustoFixo = c.Single(nullable: false),
                        MoiFabricacao = c.Single(nullable: false),
                        OutroCustoFixoFabricacao = c.Single(nullable: false),
                        CustoFixoComacs = c.Single(nullable: false),
                        CustoFixoComtex = c.Single(nullable: false),
                        CustoFixoAdminLog = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrupoRateios", t => t.GrupoRateioId, cascadeDelete: true)
                .Index(t => t.GrupoRateioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndiceRateioLucratividades", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.IndiceRateioLucratividades", new[] { "GrupoRateioId" });
            DropTable("dbo.IndiceRateioLucratividades");
        }
    }
}
