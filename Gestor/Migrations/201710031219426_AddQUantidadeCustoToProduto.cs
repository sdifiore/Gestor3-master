namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQUantidadeCustoToProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "QuantidadeCusto", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "QuantidadeCusto");
        }
    }
}
