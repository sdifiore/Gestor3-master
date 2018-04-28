namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DfxProdRev : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DfxProdRevs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        UnidadeId = c.Int(nullable: false),
                        QtdUnidade = c.Int(nullable: false),
                        QtdCompra = c.Int(nullable: false),
                        PrecoCompra = c.Single(nullable: false),
                        ValorCompra = c.Single(nullable: false),
                        RateioDfixProduto = c.Single(nullable: false),
                        RateioDfixUnidade = c.Single(nullable: false),
                        MoiFabrica = c.Single(nullable: false),
                        DespsFabrica = c.Single(nullable: false),
                        DespsDepComercial = c.Single(nullable: false),
                        DespsDeptAdminLog = c.Single(nullable: false),
                        QtdRolos = c.Int(nullable: false),
                        RateioDfixProdutoUnitario = c.Single(nullable: false),
                        ProporcaoCusto = c.Single(nullable: false),
                        ProporcaoEmCxs = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: false)
                .Index(t => t.ProdutoId)
                .Index(t => t.UnidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DfxProdRevs", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.DfxProdRevs", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.DfxProdRevs", new[] { "UnidadeId" });
            DropIndex("dbo.DfxProdRevs", new[] { "ProdutoId" });
            DropTable("dbo.DfxProdRevs");
        }
    }
}
