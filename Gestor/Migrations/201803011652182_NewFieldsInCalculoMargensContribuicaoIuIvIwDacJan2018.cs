namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFieldsInCalculoMargensContribuicaoIuIvIwDacJan2018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "McCustoModTotalAjustado", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "McCustoDirMaTotal", c => c.Single(nullable: false));
            AddColumn("dbo.PlanejVendas", "McDiretaAjustadaTotal", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "McDiretaAjustadaTotal");
            DropColumn("dbo.PlanejVendas", "McCustoDirMaTotal");
            DropColumn("dbo.PlanejVendas", "McCustoModTotalAjustado");
        }
    }
}
