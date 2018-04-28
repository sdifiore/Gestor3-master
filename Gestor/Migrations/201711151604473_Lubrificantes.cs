namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lubrificantes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lubrificantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ref = c.String(maxLength: 1),
                        Referencia = c.String(maxLength: 16),
                        InsumoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insumoes", t => t.InsumoId, cascadeDelete: true)
                .Index(t => t.InsumoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lubrificantes", "InsumoId", "dbo.Insumoes");
            DropIndex("dbo.Lubrificantes", new[] { "InsumoId" });
            DropTable("dbo.Lubrificantes");
        }
    }
}
