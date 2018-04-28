namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkDetalheEstruturaToEstutura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalheEstruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.DetalheEstruturas", new[] { "ProdutoId" });
            AddColumn("dbo.DetalheEstruturas", "EstruturaId", c => c.Int(nullable: false));
            CreateIndex("dbo.DetalheEstruturas", "EstruturaId");
            AddForeignKey("dbo.DetalheEstruturas", "EstruturaId", "dbo.Estruturas", "Id", cascadeDelete: true);
            DropColumn("dbo.DetalheEstruturas", "ProdutoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalheEstruturas", "ProdutoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DetalheEstruturas", "EstruturaId", "dbo.Estruturas");
            DropIndex("dbo.DetalheEstruturas", new[] { "EstruturaId" });
            DropColumn("dbo.DetalheEstruturas", "EstruturaId");
            CreateIndex("dbo.DetalheEstruturas", "ProdutoId");
            AddForeignKey("dbo.DetalheEstruturas", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
