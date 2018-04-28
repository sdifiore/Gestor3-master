namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAreas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 2),
                        Nome = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Areas");
        }
    }
}
