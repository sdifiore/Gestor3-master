namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMcCustoFixoFabricaAjustadoToPlanejVenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "McCustoFixoFabricaAjustado", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "McCustoFixoFabricaAjustado");
        }
    }
}
