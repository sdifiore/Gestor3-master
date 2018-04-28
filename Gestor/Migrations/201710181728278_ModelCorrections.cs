namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCorrections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustoInsumoes", "PgmtoFornecImport", c => c.Single(nullable: false));
            DropColumn("dbo.CustoInsumoes", "FgmtoFornecImport");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustoInsumoes", "FgmtoFornecImport", c => c.Single(nullable: false));
            DropColumn("dbo.CustoInsumoes", "PgmtoFornecImport");
        }
    }
}
