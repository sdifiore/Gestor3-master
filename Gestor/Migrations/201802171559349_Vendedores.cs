namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vendedores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Representante = c.String(),
                        PctComissao = c.Single(nullable: false),
                        Cidade = c.String(maxLength: 32),
                        Estado = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendedores");
        }
    }
}
