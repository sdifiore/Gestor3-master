namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteProductsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        UnidadeApelido = c.String(maxLength: 10),
                        TipoApelido = c.String(maxLength: 1),
                        ClasseCustoApelido = c.String(maxLength: 2),
                        CategoriaApelido = c.String(maxLength: 2),
                        Familia = c.String(maxLength: 3),
                        Linha = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
