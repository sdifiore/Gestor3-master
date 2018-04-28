namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParametersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parametros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Dolar = c.Single(nullable: false),
                        PropFitasFioGaxeta = c.Single(nullable: false),
                        PropSucatas = c.Single(nullable: false),
                        PropGrafitado = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parametros");
        }
    }
}
