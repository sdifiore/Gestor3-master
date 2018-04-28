namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreparoToFloatInPreforma : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PreFormas", "Preparo", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PreFormas", "Preparo", c => c.Int(nullable: false));
        }
    }
}
