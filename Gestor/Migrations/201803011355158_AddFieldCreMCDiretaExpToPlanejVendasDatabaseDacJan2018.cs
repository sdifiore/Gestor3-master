namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldCreMCDiretaExpToPlanejVendasDatabaseDacJan2018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "CreMCDiretaExp", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "CreMCDiretaExp");
        }
    }
}
