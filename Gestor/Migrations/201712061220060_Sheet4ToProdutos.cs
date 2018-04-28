namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sheet4ToProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "PropCustoFixoTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstDirUnidade", c => c.Single(nullable: false));
            AddColumn("dbo.Produtoes", "CstIndirUnidade", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "CstIndirUnidade");
            DropColumn("dbo.Produtoes", "CstDirUnidade");
            DropColumn("dbo.Produtoes", "PropCustoFixoTotal");
        }
    }
}
