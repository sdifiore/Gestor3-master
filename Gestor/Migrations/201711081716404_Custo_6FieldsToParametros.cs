namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Custo_6FieldsToParametros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parametroes", "Icms", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "Ipi", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "Inss", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "Comissão", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "Frete", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "MargemLiquida", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "ComissGestVenda", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "CondicaoPgtoStd", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "TxJuroStd", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "CustoFin", c => c.Single(nullable: false));
            AddColumn("dbo.Parametroes", "CustoCobranca", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parametroes", "CustoCobranca");
            DropColumn("dbo.Parametroes", "CustoFin");
            DropColumn("dbo.Parametroes", "TxJuroStd");
            DropColumn("dbo.Parametroes", "CondicaoPgtoStd");
            DropColumn("dbo.Parametroes", "ComissGestVenda");
            DropColumn("dbo.Parametroes", "MargemLiquida");
            DropColumn("dbo.Parametroes", "Frete");
            DropColumn("dbo.Parametroes", "Comissão");
            DropColumn("dbo.Parametroes", "Inss");
            DropColumn("dbo.Parametroes", "Ipi");
            DropColumn("dbo.Parametroes", "Icms");
        }
    }
}
