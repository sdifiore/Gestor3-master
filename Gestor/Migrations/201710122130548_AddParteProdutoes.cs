namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParteProdutoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParteProdutoes",
                c => new
                    {
                        ParteProdutoId = c.Int(nullable: false, identity: true),
                        GrupoRateioId = c.Int(nullable: false),
                        Pelo = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Ipi = c.Single(nullable: false),
                        QtdUndd = c.Int(nullable: false),
                        TipoProducaoId = c.Int(nullable: false),
                        PcpId = c.Int(nullable: false),
                        QtdUndArmz = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParteProdutoId)
                .ForeignKey("dbo.GrupoRateios", t => t.GrupoRateioId, cascadeDelete: true)
                .ForeignKey("dbo.Pcps", t => t.PcpId, cascadeDelete: true)
                .ForeignKey("dbo.TipoProducaos", t => t.TipoProducaoId, cascadeDelete: true)
                .Index(t => t.GrupoRateioId)
                .Index(t => t.TipoProducaoId)
                .Index(t => t.PcpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParteProdutoes", "TipoProducaoId", "dbo.TipoProducaos");
            DropForeignKey("dbo.ParteProdutoes", "PcpId", "dbo.Pcps");
            DropForeignKey("dbo.ParteProdutoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.ParteProdutoes", new[] { "PcpId" });
            DropIndex("dbo.ParteProdutoes", new[] { "TipoProducaoId" });
            DropIndex("dbo.ParteProdutoes", new[] { "GrupoRateioId" });
            DropTable("dbo.ParteProdutoes");
        }
    }
}
