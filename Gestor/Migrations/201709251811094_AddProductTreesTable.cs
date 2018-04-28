namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductTreesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 10),
                        ProdutoId = c.String(maxLength: 10),
                        Unidade = c.String(maxLength: 2),
                        Sequencia = c.String(maxLength: 2),
                        QuantitadeCusto = c.Single(),
                        ClasseCusto = c.Byte(),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductTrees");
        }
    }
}
