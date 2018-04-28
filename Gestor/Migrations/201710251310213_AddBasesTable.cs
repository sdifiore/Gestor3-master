namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bases",
                c => new
                    {
                        BaseId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        UnidadeId = c.Int(nullable: false),
                        TipoId = c.Int(nullable: false),
                        ClasseCustoId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        FamiliaId = c.Int(nullable: false),
                        LinhaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BaseId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.ClasseCustoes", t => t.ClasseCustoId, cascadeDelete: true)
                .ForeignKey("dbo.Familias", t => t.FamiliaId, cascadeDelete: true)
                .ForeignKey("dbo.Linhas", t => t.LinhaId, cascadeDelete: true)
                .ForeignKey("dbo.Tipoes", t => t.TipoId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.UnidadeId)
                .Index(t => t.TipoId)
                .Index(t => t.ClasseCustoId)
                .Index(t => t.CategoriaId)
                .Index(t => t.FamiliaId)
                .Index(t => t.LinhaId);
            
            AddColumn("dbo.Insumoes", "Descricao", c => c.String(maxLength: 100));
            AddColumn("dbo.Insumoes", "UnidadeId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "TipoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "ClasseCustoId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "FamiliaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "LinhaId", c => c.Int(nullable: false));
            AddColumn("dbo.Insumoes", "Unidade_UnidadeId", c => c.Int());
            CreateIndex("dbo.Insumoes", "TipoId");
            CreateIndex("dbo.Insumoes", "ClasseCustoId");
            CreateIndex("dbo.Insumoes", "CategoriaId");
            CreateIndex("dbo.Insumoes", "FamiliaId");
            CreateIndex("dbo.Insumoes", "LinhaId");
            CreateIndex("dbo.Insumoes", "Unidade_UnidadeId");
            AddForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes", "ClasseCustoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes", "TipoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades", "UnidadeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Bases", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Bases", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Bases", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Bases", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Bases", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Bases", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Insumoes", new[] { "Unidade_UnidadeId" });
            DropIndex("dbo.Insumoes", new[] { "LinhaId" });
            DropIndex("dbo.Insumoes", new[] { "FamiliaId" });
            DropIndex("dbo.Insumoes", new[] { "CategoriaId" });
            DropIndex("dbo.Insumoes", new[] { "ClasseCustoId" });
            DropIndex("dbo.Insumoes", new[] { "TipoId" });
            DropIndex("dbo.Bases", new[] { "LinhaId" });
            DropIndex("dbo.Bases", new[] { "FamiliaId" });
            DropIndex("dbo.Bases", new[] { "CategoriaId" });
            DropIndex("dbo.Bases", new[] { "ClasseCustoId" });
            DropIndex("dbo.Bases", new[] { "TipoId" });
            DropIndex("dbo.Bases", new[] { "UnidadeId" });
            DropColumn("dbo.Insumoes", "Unidade_UnidadeId");
            DropColumn("dbo.Insumoes", "LinhaId");
            DropColumn("dbo.Insumoes", "FamiliaId");
            DropColumn("dbo.Insumoes", "CategoriaId");
            DropColumn("dbo.Insumoes", "ClasseCustoId");
            DropColumn("dbo.Insumoes", "TipoId");
            DropColumn("dbo.Insumoes", "UnidadeId");
            DropColumn("dbo.Insumoes", "Descricao");
            DropTable("dbo.Bases");
        }
    }
}
