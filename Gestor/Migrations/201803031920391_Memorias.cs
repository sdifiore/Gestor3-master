namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Memorias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PvIncrementoGlobal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Memorias");
        }
    }
}
