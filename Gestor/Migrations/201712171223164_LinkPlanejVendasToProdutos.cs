namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkPlanejVendasToProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.PlanejVendas", "ProdutoId");
            AddForeignKey("dbo.PlanejVendas", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            DropColumn("dbo.PlanejVendas", "Apelido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanejVendas", "Apelido", c => c.String(maxLength: 10));
            DropForeignKey("dbo.PlanejVendas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.PlanejVendas", new[] { "ProdutoId" });
            DropColumn("dbo.PlanejVendas", "ProdutoId");
        }
    }
}
