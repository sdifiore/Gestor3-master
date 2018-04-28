namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQtUnidIndividualFieldToFatHistoricoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FatHistoricoes", "QtUnidIndividual", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FatHistoricoes", "QtUnidIndividual");
        }
    }
}
