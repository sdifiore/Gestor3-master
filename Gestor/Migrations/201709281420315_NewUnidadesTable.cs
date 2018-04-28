namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUnidadesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Unidades",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 2),
                        Description = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Unidades");
        }
    }
}
