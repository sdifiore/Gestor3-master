namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkLinhasToProdutoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "LinhaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "LinhaId");
            AddForeignKey("dbo.Produtoes", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "LinhaId", "dbo.Linhas");
            DropIndex("dbo.Produtoes", new[] { "LinhaId" });
            DropColumn("dbo.Produtoes", "LinhaId");
        }
    }
}
