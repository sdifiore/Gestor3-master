namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        Unidade = c.String(maxLength: 10),
                        Tipo = c.String(maxLength: 1),
                        ClasseCusto = c.String(maxLength: 2),
                        Categoria = c.String(maxLength: 2),
                        Familia = c.String(maxLength: 3),
                        Linha = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
