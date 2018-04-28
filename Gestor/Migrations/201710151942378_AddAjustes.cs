namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAjustes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ajustes",
                c => new
                    {
                        AjusteId = c.Int(nullable: false, identity: true),
                        OrigemId = c.Int(nullable: false),
                        AtualId = c.Int(nullable: false),
                        Fator = c.Single(nullable: false),
                        TipoAlteracaoId = c.Int(nullable: false),
                        Medida = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.AjusteId)
                .ForeignKey("dbo.Produtoes", t => t.AtualId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.OrigemId, cascadeDelete: false)
                .ForeignKey("dbo.TipoAlteracaos", t => t.TipoAlteracaoId, cascadeDelete: true)
                .Index(t => t.OrigemId)
                .Index(t => t.AtualId)
                .Index(t => t.TipoAlteracaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ajustes", "TipoAlteracaoId", "dbo.TipoAlteracaos");
            DropForeignKey("dbo.Ajustes", "OrigemId", "dbo.Produtoes");
            DropForeignKey("dbo.Ajustes", "AtualId", "dbo.Produtoes");
            DropIndex("dbo.Ajustes", new[] { "TipoAlteracaoId" });
            DropIndex("dbo.Ajustes", new[] { "AtualId" });
            DropIndex("dbo.Ajustes", new[] { "OrigemId" });
            DropTable("dbo.Ajustes");
        }
    }
}
