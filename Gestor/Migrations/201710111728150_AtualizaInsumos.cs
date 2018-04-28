namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizaInsumos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades");
            DropIndex("dbo.Insumoes", new[] { "TipoId" });
            DropIndex("dbo.Insumoes", new[] { "ClasseCustoId" });
            DropIndex("dbo.Insumoes", new[] { "CategoriaId" });
            DropIndex("dbo.Insumoes", new[] { "FamiliaId" });
            DropIndex("dbo.Insumoes", new[] { "LinhaId" });
            DropIndex("dbo.Insumoes", new[] { "Unidade_UnidadeId" });
            DropColumn("dbo.Insumoes", "Descricao");
            DropColumn("dbo.Insumoes", "UnidadeId");
            DropColumn("dbo.Insumoes", "TipoId");
            DropColumn("dbo.Insumoes", "ClasseCustoId");
            DropColumn("dbo.Insumoes", "CategoriaId");
            DropColumn("dbo.Insumoes", "FamiliaId");
            DropColumn("dbo.Insumoes", "LinhaId");
            DropColumn("dbo.Insumoes", "QuantidadeCusto");
            DropColumn("dbo.Insumoes", "Unidade_UnidadeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Insumoes", "Unidade_UnidadeId", c => c.Int());
            AddColumn("dbo.Insumoes", "QuantidadeCusto", c => c.Single(nullable: false));
            AddColumn("dbo.Insumoes", "LinhaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "FamiliaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "ClasseCustoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "TipoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "UnidadeId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "Descricao", c => c.String(maxLength: 100));
            CreateIndex("dbo.Insumoes", "Unidade_UnidadeId");
            CreateIndex("dbo.Insumoes", "LinhaId");
            CreateIndex("dbo.Insumoes", "FamiliaId");
            CreateIndex("dbo.Insumoes", "CategoriaId");
            CreateIndex("dbo.Insumoes", "ClasseCustoId");
            CreateIndex("dbo.Insumoes", "TipoId");
            AddForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades", "UnidadeId");
            AddForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes", "TipoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes", "ClasseCustoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
    }
}
