namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinksClasseCustoesToProdutoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "ClasseCustoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "ClasseCustoId");
            AddForeignKey("dbo.Produtoes", "ClasseCustoId", "dbo.ClasseCustoes", "ClasseCustoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropIndex("dbo.Produtoes", new[] { "ClasseCustoId" });
            DropColumn("dbo.Produtoes", "ClasseCustoId");
        }
    }
}
