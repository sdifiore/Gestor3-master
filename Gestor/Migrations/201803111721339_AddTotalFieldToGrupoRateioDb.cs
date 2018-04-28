namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalFieldToGrupoRateioDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GrupoRateios", "Total", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GrupoRateios", "Total");
        }
    }
}
