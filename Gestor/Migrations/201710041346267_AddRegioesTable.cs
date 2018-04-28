namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegioesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regiaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 2),
                        Descricao = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regiaos");
        }
    }
}
