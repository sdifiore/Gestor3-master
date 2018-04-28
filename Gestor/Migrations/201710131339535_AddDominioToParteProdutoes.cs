namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDominioToParteProdutoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParteProdutoes", "DominioId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParteProdutoes", "DominioId");
            AddForeignKey("dbo.ParteProdutoes", "DominioId", "dbo.Dominios", "DominioId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParteProdutoes", "DominioId", "dbo.Dominios");
            DropIndex("dbo.ParteProdutoes", new[] { "DominioId" });
            DropColumn("dbo.ParteProdutoes", "DominioId");
        }
    }
}
