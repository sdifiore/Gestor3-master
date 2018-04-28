namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALteraracaoParametros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parametroes", "HMod", c => c.Int(nullable: false));
            AddColumn("dbo.Parametroes", "CustoFixoIndustrialAno", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "CustoFixoComercialAno", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "CustoFixoComtexAno", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "CustoFixoAdminAno", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "ComissaoGcComacs", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parametroes", "ComissaoGcComacs");
            DropColumn("dbo.Parametroes", "CustoFixoAdminAno");
            DropColumn("dbo.Parametroes", "CustoFixoComtexAno");
            DropColumn("dbo.Parametroes", "CustoFixoComercialAno");
            DropColumn("dbo.Parametroes", "CustoFixoIndustrialAno");
            DropColumn("dbo.Parametroes", "HMod");
        }
    }
}
