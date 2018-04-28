namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProdutoesTableWithRightKeysToUnidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        UnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.UnidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "UnidadeId", "dbo.Unidades");
            DropIndex("dbo.Produtoes", new[] { "UnidadeId" });
            DropTable("dbo.Produtoes");
        }
    }
}
