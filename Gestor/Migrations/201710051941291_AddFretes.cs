namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFretes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fretes",
                c => new
                    {
                        FreteId = c.Int(nullable: false, identity: true),
                        CifGrandeSp = c.Single(nullable: false),
                        CifForaGrandeSp = c.Single(nullable: false),
                        RegioesIcms18 = c.Single(nullable: false),
                        RegioesIcms12 = c.Single(nullable: false),
                        RegioesIcms7 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FreteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fretes");
        }
    }
}
