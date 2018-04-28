namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetEndTubos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EncapTuboes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        UnidadeId = c.Int(nullable: false),
                        DextRevest = c.Single(nullable: false),
                        ResinaBase = c.String(maxLength: 10),
                        Aditivo = c.String(maxLength: 10),
                        DenRev = c.Single(nullable: false),
                        PesoRevest = c.Single(nullable: false),
                        VelRevest = c.Int(nullable: false),
                        PctCarga = c.Single(nullable: false),
                        Resina = c.Single(nullable: false),
                        Master = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: false)
                .Index(t => t.ProdutoId)
                .Index(t => t.UnidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EncapTuboes", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.EncapTuboes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.EncapTuboes", new[] { "UnidadeId" });
            DropIndex("dbo.EncapTuboes", new[] { "ProdutoId" });
            DropTable("dbo.EncapTuboes");
        }
    }
}
