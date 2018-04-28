namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDespExpToMemoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memorias", "DespExp", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memorias", "DespExp");
        }
    }
}
