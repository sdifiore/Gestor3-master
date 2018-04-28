namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Embals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Embals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sigla = c.String(maxLength: 24),
                        InsumoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insumoes", t => t.InsumoId, cascadeDelete: true)
                .Index(t => t.InsumoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Embals", "InsumoId", "dbo.Insumoes");
            DropIndex("dbo.Embals", new[] { "InsumoId" });
            DropTable("dbo.Embals");
        }
    }
}
