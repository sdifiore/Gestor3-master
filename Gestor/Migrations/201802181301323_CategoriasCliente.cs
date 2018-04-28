namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriasCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriasCliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Categoria = c.String(maxLength: 32),
                        Descricao = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategoriasCliente");
        }
    }
}
