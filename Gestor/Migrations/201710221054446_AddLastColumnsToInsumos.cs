namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastColumnsToInsumos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insumoes", "CustoExtra", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "Custo", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "CustoUndCnsm", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "PgtFornecImp", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insumoes", "PgtFornecImp");
            DropColumn("dbo.Insumoes", "CustoUndCnsm");
            DropColumn("dbo.Insumoes", "Custo");
            DropColumn("dbo.Insumoes", "CustoExtra");
        }
    }
}
