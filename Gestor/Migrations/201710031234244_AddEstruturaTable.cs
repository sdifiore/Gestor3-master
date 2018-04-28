namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstruturaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estruturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        ProdutoId = c.Int(nullable: false),
                        Sequencia = c.String(maxLength: 2),
                        Onera = c.Boolean(nullable: false),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "ProdutoId" });
            DropTable("dbo.Estruturas");
        }
    }
}
