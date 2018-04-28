namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsoStruToInsumos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insumoes", "UsoStru", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insumoes", "UsoStru");
        }
    }
}
