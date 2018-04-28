namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QtUnidIndividualInFatHistoricoToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FatHistoricoes", "QtUnidIndividual", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FatHistoricoes", "QtUnidIndividual", c => c.String(maxLength: 512));
        }
    }
}
