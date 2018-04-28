namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndiceRateioFormacaoPrecoVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndiceRateioFormacaoPrecoVendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalCustoFixo = c.Single(nullable: false),
                        MoiFabricacao = c.Single(nullable: false),
                        OutroCustoFixoFabricacao = c.Single(nullable: false),
                        CustoFixoComacs = c.Single(nullable: false),
                        CustoFixoComtex = c.Single(nullable: false),
                        CustoFixoAdminLog = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IndiceRateioFormacaoPrecoVendas");
        }
    }
}
