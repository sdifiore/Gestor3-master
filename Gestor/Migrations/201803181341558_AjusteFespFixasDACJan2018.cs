namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteFespFixasDACJan2018 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DespesaFixas", "RateioSucatas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DespesaFixas", "RateioSucatas", c => c.Single(nullable: false));
        }
    }
}
