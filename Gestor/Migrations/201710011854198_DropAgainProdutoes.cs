namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAgainProdutoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Produtoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Produtoes", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios");
            DropForeignKey("dbo.Produtoes", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Produtoes", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Produtoes", "UnidadeId", "dbo.Unidades");
            DropIndex("dbo.Produtoes", new[] { "UnidadeId" });
            DropIndex("dbo.Produtoes", new[] { "TipoId" });
            DropIndex("dbo.Produtoes", new[] { "ClasseCustoId" });
            DropIndex("dbo.Produtoes", new[] { "FamiliaId" });
            DropIndex("dbo.Produtoes", new[] { "LinhaId" });
            DropIndex("dbo.Produtoes", new[] { "GrupoRateioId" });
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            DropTable("dbo.Produtoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        UnidadeId = c.Int(nullable: false),
                        TipoId = c.Int(nullable: false),
                        ClasseCustoId = c.Int(nullable: false),
                        FamiliaId = c.Int(nullable: false),
                        LinhaId = c.Int(nullable: false),
                        GrupoRateioId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Produtoes", "CategoriaId");
            CreateIndex("dbo.Produtoes", "GrupoRateioId");
            CreateIndex("dbo.Produtoes", "LinhaId");
            CreateIndex("dbo.Produtoes", "FamiliaId");
            CreateIndex("dbo.Produtoes", "ClasseCustoId");
            CreateIndex("dbo.Produtoes", "TipoId");
            CreateIndex("dbo.Produtoes", "UnidadeId");
            AddForeignKey("dbo.Produtoes", "UnidadeId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "TipoId", "dbo.Tipoes", "TipoId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "ClasseCustoId", "dbo.ClasseCustoes", "ClasseCustoId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
    }
}
