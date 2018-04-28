namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkInssumoToBaseInstead : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Insumoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas");
            DropIndex("dbo.Insumoes", new[] { "TipoId" });
            DropIndex("dbo.Insumoes", new[] { "ClasseCustoId" });
            DropIndex("dbo.Insumoes", new[] { "CategoriaId" });
            DropIndex("dbo.Insumoes", new[] { "FamiliaId" });
            DropIndex("dbo.Insumoes", new[] { "LinhaId" });
            DropIndex("dbo.Insumoes", new[] { "ProdutoId" });
            DropIndex("dbo.Insumoes", new[] { "Unidade_UnidadeId" });
            RenameColumn(table: "dbo.Insumoes", name: "LinhaId", newName: "Linha_LinhaId");
            AddColumn("dbo.Insumoes", "BaseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Insumoes", "Linha_LinhaId", c => c.Int());
            CreateIndex("dbo.Insumoes", "BaseId");
            CreateIndex("dbo.Insumoes", "Linha_LinhaId");
            AddForeignKey("dbo.Insumoes", "BaseId", "dbo.Bases", "BaseId", cascadeDelete: false);
            AddForeignKey("dbo.Insumoes", "Linha_LinhaId", "dbo.Linhas", "LinhaId");
            DropColumn("dbo.Insumoes", "Apelido");
            DropColumn("dbo.Insumoes", "Descricao");
            DropColumn("dbo.Insumoes", "UnidadeId");
            DropColumn("dbo.Insumoes", "TipoId");
            DropColumn("dbo.Insumoes", "ClasseCustoId");
            DropColumn("dbo.Insumoes", "CategoriaId");
            DropColumn("dbo.Insumoes", "FamiliaId");
            DropColumn("dbo.Insumoes", "ProdutoId");
            DropColumn("dbo.Insumoes", "Unidade_UnidadeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Insumoes", "Unidade_UnidadeId", c => c.Int());
            AddColumn("dbo.Insumoes", "ProdutoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "FamiliaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "ClasseCustoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "TipoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "UnidadeId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "Descricao", c => c.String(maxLength: 100));
            AddColumn("dbo.Insumoes", "Apelido", c => c.String(maxLength: 10));
            DropForeignKey("dbo.Insumoes", "Linha_LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Insumoes", "BaseId", "dbo.Bases");
            DropIndex("dbo.Insumoes", new[] { "Linha_LinhaId" });
            DropIndex("dbo.Insumoes", new[] { "BaseId" });
            AlterColumn("dbo.Insumoes", "Linha_LinhaId", c => c.Int(nullable: false));
            DropColumn("dbo.Insumoes", "BaseId");
            RenameColumn(table: "dbo.Insumoes", name: "Linha_LinhaId", newName: "LinhaId");
            CreateIndex("dbo.Insumoes", "Unidade_UnidadeId");
            CreateIndex("dbo.Insumoes", "ProdutoId");
            CreateIndex("dbo.Insumoes", "LinhaId");
            CreateIndex("dbo.Insumoes", "FamiliaId");
            CreateIndex("dbo.Insumoes", "CategoriaId");
            CreateIndex("dbo.Insumoes", "ClasseCustoId");
            CreateIndex("dbo.Insumoes", "TipoId");
            AddForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades", "UnidadeId");
            AddForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes", "TipoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes", "ClasseCustoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
    }
}
