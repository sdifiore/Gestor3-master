namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCotacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cotacaos",
                c => new
                    {
                        CotacaoId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CotacaoId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cotacaos", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Cotacaos", new[] { "ProdutoId" });
            DropTable("dbo.Cotacaos");
        }
    }
}
