namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongerStringsInInsumoXtd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InsumoXtds", "Cotacao", c => c.String(maxLength: 1024));
            AlterColumn("dbo.InsumoXtds", "FormaPgto", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InsumoXtds", "FormaPgto", c => c.String(maxLength: 8));
            AlterColumn("dbo.InsumoXtds", "Cotacao", c => c.String(maxLength: 256));
        }
    }
}
