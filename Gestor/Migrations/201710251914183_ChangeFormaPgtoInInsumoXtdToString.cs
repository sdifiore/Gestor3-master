namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFormaPgtoInInsumoXtdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InsumoXtds", "FormaPgto", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InsumoXtds", "FormaPgto", c => c.Int(nullable: false));
        }
    }
}
