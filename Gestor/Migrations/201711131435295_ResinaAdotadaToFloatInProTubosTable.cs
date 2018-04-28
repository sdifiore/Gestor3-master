namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResinaAdotadaToFloatInProTubosTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProcTuboes", "CodResinaAdotada", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProcTuboes", "CodResinaAdotada", c => c.Int(nullable: false));
        }
    }
}
