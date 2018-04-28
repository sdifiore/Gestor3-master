namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToFrete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fretes", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fretes", "Data");
        }
    }
}
