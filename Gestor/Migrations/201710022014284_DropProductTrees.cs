namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropProductTrees : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ProductTrees");
        }
        
        public override void Down()
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
    }
}
