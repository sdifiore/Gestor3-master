namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinksFamiliasToProdutoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "FamiliaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "FamiliaId");
            AddForeignKey("dbo.Produtoes", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "FamiliaId", "dbo.Familias");
            DropIndex("dbo.Produtoes", new[] { "FamiliaId" });
            DropColumn("dbo.Produtoes", "FamiliaId");
        }
    }
}
