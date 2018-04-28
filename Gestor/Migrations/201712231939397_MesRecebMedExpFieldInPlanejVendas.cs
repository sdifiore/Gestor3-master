namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MesRecebMedExpFieldInPlanejVendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "MesRecebMedExp", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "MesRecebMedExp");
        }
    }
}
