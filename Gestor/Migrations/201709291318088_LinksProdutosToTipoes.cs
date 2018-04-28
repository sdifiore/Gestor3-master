namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinksProdutosToTipoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "TipoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "TipoId");
            AddForeignKey("dbo.Produtoes", "TipoId", "dbo.Tipoes", "TipoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "TipoId", "dbo.Tipoes");
            DropIndex("dbo.Produtoes", new[] { "TipoId" });
            DropColumn("dbo.Produtoes", "TipoId");
        }
    }
}
