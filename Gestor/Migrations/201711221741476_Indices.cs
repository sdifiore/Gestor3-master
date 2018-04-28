namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Indices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 128),
                        Proprio = c.Single(nullable: false),
                        Terceiros = c.Single(nullable: false),
                        Exportacao = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Indices");
        }
    }
}
