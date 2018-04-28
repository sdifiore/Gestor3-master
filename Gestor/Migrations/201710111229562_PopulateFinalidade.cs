namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFinalidade : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into dbo.Finalidades (Descricao) Values ('Consumo')");
            Sql("Insert into dbo.Finalidades (Descricao) Values ('Industrializa��o')");
            Sql("Insert into dbo.Finalidades (Descricao) Values ('Revenda')");
        }

        public override void Down()
        {
        }
    }
}
