namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPesoNStatusToProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Peso", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Status");
            DropColumn("dbo.Produtoes", "Peso");
        }
    }
}
