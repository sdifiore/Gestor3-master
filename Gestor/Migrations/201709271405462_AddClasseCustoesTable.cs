namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClasseCustoesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClasseCustoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 2),
                        Descricao = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClasseCustoes");
        }
    }
}
