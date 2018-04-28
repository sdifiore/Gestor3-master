namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatDespFixas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatDespFixas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categoria = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CatDespFixas");
        }
    }
}
