namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEstrutura1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estruturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        UnidadeId = c.Int(nullable: false),
                        QtdCusto = c.Single(nullable: false),
                        SequenciaId = c.Int(nullable: false),
                        Item = c.String(maxLength: 10),
                        ProdutoId = c.Int(nullable: false),
                        Onera = c.Boolean(nullable: false),
                        Lote = c.Single(nullable: false),
                        Perda = c.Single(nullable: false),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Sequencias", t => t.SequenciaId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: false)
                .Index(t => t.UnidadeId)
                .Index(t => t.SequenciaId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estruturas", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Estruturas", "SequenciaId", "dbo.Sequencias");
            DropForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Estruturas", new[] { "ProdutoId" });
            DropIndex("dbo.Estruturas", new[] { "SequenciaId" });
            DropIndex("dbo.Estruturas", new[] { "UnidadeId" });
            DropTable("dbo.Estruturas");
        }
    }
}
