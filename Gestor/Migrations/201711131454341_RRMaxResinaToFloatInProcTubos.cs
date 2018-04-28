namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RRMaxResinaToFloatInProcTubos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProcTuboes", "RrMaxResina", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProcTuboes", "RrMaxResina", c => c.Int(nullable: false));
        }
    }
}
