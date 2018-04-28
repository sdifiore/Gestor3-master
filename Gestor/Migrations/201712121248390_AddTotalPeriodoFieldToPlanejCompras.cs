namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalPeriodoFieldToPlanejCompras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejCompras", "TotalPeriodo", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejCompras", "TotalPeriodo");
        }
    }
}
