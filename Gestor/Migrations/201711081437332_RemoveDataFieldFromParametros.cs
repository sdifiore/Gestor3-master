namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDataFieldFromParametros : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Parametroes", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parametroes", "Data", c => c.DateTime(nullable: false));
        }
    }
}
