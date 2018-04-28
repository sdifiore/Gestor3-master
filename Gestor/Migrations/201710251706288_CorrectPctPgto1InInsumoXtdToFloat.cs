namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectPctPgto1InInsumoXtdToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InsumoXtds", "PctPgto1", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InsumoXtds", "PctPgto1", c => c.Int(nullable: false));
        }
    }
}
