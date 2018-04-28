namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsumoesb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insumoes",
                c => new
                    {
                        InsumoId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Peso = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                        FinalidadeId = c.Int(nullable: false),
                        UnddId = c.Int(nullable: false),
                        QtdUnddConsumo = c.Single(nullable: false),
                        QtdMltplCompra = c.Single(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsumoId)
                .ForeignKey("dbo.Finalidades", t => t.FinalidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: false)
                .ForeignKey("dbo.Unidades", t => t.UnddId, cascadeDelete: true)
                .Index(t => t.FinalidadeId)
                .Index(t => t.UnddId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades");
            DropIndex("dbo.Insumoes", new[] { "ProdutoId" });
            DropIndex("dbo.Insumoes", new[] { "UnddId" });
            DropIndex("dbo.Insumoes", new[] { "FinalidadeId" });
            DropTable("dbo.Insumoes");
        }
    }
}
