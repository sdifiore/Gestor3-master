namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustoTotalToCustoUnitarioInCustoCargoDireto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustoCargoDiretoes", "CustoUnitario", c => c.Single(nullable: false));
            DropColumn("dbo.CustoCargoDiretoes", "CustoTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustoCargoDiretoes", "CustoTotal", c => c.Single(nullable: false));
            DropColumn("dbo.CustoCargoDiretoes", "CustoUnitario");
        }
    }
}
