namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecuperadoPosMemoryLostDropBox : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FatHistoricoes", "QuantUnidIndividual");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FatHistoricoes", "QuantUnidIndividual", c => c.Single(nullable: false));
        }
    }
}
