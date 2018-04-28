namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRaeios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rateios",
                c => new
                    {
                        RateioId = c.Int(nullable: false, identity: true),
                        Grupo = c.String(maxLength: 20),
                        Horas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RateioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rateios");
        }
    }
}
