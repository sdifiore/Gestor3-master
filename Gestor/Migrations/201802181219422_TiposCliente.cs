namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TiposCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposCliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(maxLength: 16),
                        Descricao = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TiposCliente");
        }
    }
}
