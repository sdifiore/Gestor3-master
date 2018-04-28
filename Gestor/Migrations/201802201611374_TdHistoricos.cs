namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TdHistoricos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TdHistoricos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Totalizador = c.String(maxLength: 16),
                        PropRecLiq = c.Single(nullable: false),
                        PropPeso = c.Single(nullable: false),
                        PropHoras = c.Single(nullable: false),
                        PropQuant = c.Single(nullable: false),
                        TercRecLiq = c.Single(nullable: false),
                        TercPeso = c.Single(nullable: false),
                        TercHoras = c.Single(nullable: false),
                        TercQuant = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TdHistoricos");
        }
    }
}
