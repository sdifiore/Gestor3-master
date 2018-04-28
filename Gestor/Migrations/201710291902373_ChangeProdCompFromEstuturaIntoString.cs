namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProdCompFromEstuturaIntoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estruturas", "ProdComp", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estruturas", "ProdComp", c => c.Single(nullable: false));
        }
    }
}
