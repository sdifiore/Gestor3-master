namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateParametroes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Parametroes (Data, Dolar, PropFitasFioGaxeta, PropSucatas, PropGrafitado) Values (17/02/2017, 3.5, 65, 96, 65)");
        }
        
        public override void Down()
        {
        }
    }
}
