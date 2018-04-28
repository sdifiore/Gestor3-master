namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInputFieldToRstruturasTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "Input", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estruturas", "Input");
        }
    }
}
