namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPrecoRsToCotacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insumoes", "PrecoRs", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insumoes", "PrecoRs");
        }
    }
}
