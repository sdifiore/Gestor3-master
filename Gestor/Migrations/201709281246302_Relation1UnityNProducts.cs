namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation1UnityNProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Unit_Id", c => c.Int());
            CreateIndex("dbo.Products", "Unit_Id");
            AddForeignKey("dbo.Products", "Unit_Id", "dbo.Units", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Products", new[] { "Unit_Id" });
            DropColumn("dbo.Products", "Unit_Id");
        }
    }
}
