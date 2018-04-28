namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vlcomFieldFloatInCuboTrabalhadoTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CubosTrabalhados", "VlCom", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CubosTrabalhados", "VlCom", c => c.String());
        }
    }
}
