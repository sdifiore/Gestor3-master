namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ufs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ufs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sigla = c.String(maxLength: 2),
                        Nome = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ufs");
        }
    }
}
