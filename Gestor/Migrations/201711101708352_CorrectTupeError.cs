namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectTupeError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PreFormas", "Preparo", c => c.Int(nullable: false));
            AlterColumn("dbo.PreFormas", "TrocaPf", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PreFormas", "TrocaPf", c => c.Int(nullable: false));
            AlterColumn("dbo.PreFormas", "Preparo", c => c.Single(nullable: false));
        }
    }
}
