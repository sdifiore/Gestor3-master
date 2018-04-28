namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFieldToCustoFixoAdminLogFpvInProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "CustoFixoAdminLogFpv", c => c.Single(nullable: false));
            DropColumn("dbo.Produtoes", "CustoFixoAdminFpv");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "CustoFixoAdminFpv", c => c.Single(nullable: false));
            DropColumn("dbo.Produtoes", "CustoFixoAdminLogFpv");
        }
    }
}
