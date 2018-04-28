namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RrFieldInProcTubosToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProcTuboes", "Rr", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProcTuboes", "Rr", c => c.Int(nullable: false));
        }
    }
}
