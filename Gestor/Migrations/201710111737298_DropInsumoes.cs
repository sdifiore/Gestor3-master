namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropInsumoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades");
            DropForeignKey("dbo.Insumoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades");
            DropIndex("dbo.Insumoes", new[] { "FinalidadeId" });
            DropIndex("dbo.Insumoes", new[] { "UnddId" });
            DropIndex("dbo.Insumoes", new[] { "ProdutoId" });
            DropTable("dbo.Insumoes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.InsumoId);
            
            CreateIndex("dbo.Insumoes", "ProdutoId");
            CreateIndex("dbo.Insumoes", "UnddId");
            CreateIndex("dbo.Insumoes", "FinalidadeId");
            AddForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades", "FinalidadeId", cascadeDelete: true);
        }
    }
}
