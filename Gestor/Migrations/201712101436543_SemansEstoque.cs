namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SemansEstoque : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SemanaEstoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Semanas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SemanaEstoques");
        }
    }
}
