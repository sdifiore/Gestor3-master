namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreGraxa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Graxas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        EmbalagemId = c.Int(nullable: false),
                        Peso = c.Single(nullable: false),
                        PctSilicone = c.Single(nullable: false),
                        PctSilica = c.Single(nullable: false),
                        PctPtfe = c.Single(nullable: false),
                        ResinaId = c.Int(nullable: false),
                        PesagemMinUn = c.Single(nullable: false),
                        Mistura = c.Single(nullable: false),
                        EmbalagemMedida = c.Single(nullable: false),
                        Rotulagem = c.Single(nullable: false),
                        LoteMinino = c.Single(nullable: false),
                        Ptfe = c.Single(nullable: false),
                        Silicone = c.Single(nullable: false),
                        Silica = c.Single(nullable: false),
                        PesagemH = c.Single(nullable: false),
                        MisturaH = c.Single(nullable: false),
                        EmbalarH = c.Single(nullable: false),
                        RotularH = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Embals", t => t.EmbalagemId, cascadeDelete: true)
                .ForeignKey("dbo.Resinas", t => t.ResinaId, cascadeDelete: true)
                .Index(t => t.EmbalagemId)
                .Index(t => t.ResinaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Graxas", "ResinaId", "dbo.Resinas");
            DropForeignKey("dbo.Graxas", "EmbalagemId", "dbo.Embals");
            DropIndex("dbo.Graxas", new[] { "ResinaId" });
            DropIndex("dbo.Graxas", new[] { "EmbalagemId" });
            DropTable("dbo.Graxas");
        }
    }
}
