namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSucatas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sucatas",
                c => new
                    {
                        SucataId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Cartucho = c.Single(nullable: false),
                        Carretel = c.Single(nullable: false),
                        CRefile = c.Single(nullable: false),
                        Jumbo216 = c.Single(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SucataId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sucatas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Sucatas", new[] { "ProdutoId" });
            DropTable("dbo.Sucatas");
        }
    }
}
