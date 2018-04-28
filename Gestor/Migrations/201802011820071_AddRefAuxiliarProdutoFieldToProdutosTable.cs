namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRefAuxiliarProdutoFieldToProdutosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "RefAuxiliarProduto", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "RefAuxiliarProduto");
        }
    }
}
