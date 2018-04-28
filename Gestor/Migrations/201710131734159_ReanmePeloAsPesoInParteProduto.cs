namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReanmePeloAsPesoInParteProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParteProdutoes", "Peso", c => c.Single(nullable: false));
            DropColumn("dbo.ParteProdutoes", "Pelo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParteProdutoes", "Pelo", c => c.Single(nullable: false));
            DropColumn("dbo.ParteProdutoes", "Peso");
        }
    }
}
