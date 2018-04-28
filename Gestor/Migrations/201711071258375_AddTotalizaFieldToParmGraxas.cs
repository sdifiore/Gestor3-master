namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalizaFieldToParmGraxas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParmGraxas", "Totaliza", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParmGraxas", "Totaliza");
        }
    }
}
