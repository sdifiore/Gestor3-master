namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEstrutura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Estruturas", "SequenciaId", "dbo.Sequencias");
            DropForeignKey("dbo.Estruturas", "UnddId", "dbo.Unidades");
            DropIndex("dbo.Estruturas", new[] { "UnddId" });
            DropIndex("dbo.Estruturas", new[] { "SequenciaId" });
            DropIndex("dbo.Estruturas", new[] { "ProdutoId" });
            DropTable("dbo.Estruturas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Estruturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        UnddId = c.Int(nullable: false),
                        QtdCusto = c.Single(nullable: false),
                        SequenciaId = c.Int(nullable: false),
                        Item = c.String(maxLength: 10),
                        ProdutoId = c.Int(nullable: false),
                        Onera = c.Boolean(nullable: false),
                        Lote = c.Single(nullable: false),
                        Perda = c.Single(nullable: false),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Estruturas", "ProdutoId");
            CreateIndex("dbo.Estruturas", "SequenciaId");
            CreateIndex("dbo.Estruturas", "UnddId");
            AddForeignKey("dbo.Estruturas", "UnddId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
            AddForeignKey("dbo.Estruturas", "SequenciaId", "dbo.Sequencias", "SequenciaId", cascadeDelete: true);
            AddForeignKey("dbo.Estruturas", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
