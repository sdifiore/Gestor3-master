namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveParametros : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Parametros");
        }
        
        public override void Down()
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
    }
}
