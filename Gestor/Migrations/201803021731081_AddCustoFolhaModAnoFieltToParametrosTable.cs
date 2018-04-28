namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustoFolhaModAnoFieltToParametrosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parametroes", "CustoFolhaModAno", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parametroes", "CustoFolhaModAno");
        }
    }
}
