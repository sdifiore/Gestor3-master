namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IcmsFrete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IcmsFretes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rotulo = c.String(maxLength: 16),
                        Icms = c.Single(nullable: false),
                        Frete = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IcmsFretes");
        }
    }
}
