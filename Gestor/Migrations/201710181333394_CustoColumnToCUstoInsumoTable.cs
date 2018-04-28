namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustoColumnToCUstoInsumoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustoInsumoes", "Custo", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustoInsumoes", "Custo");
        }
    }
}
