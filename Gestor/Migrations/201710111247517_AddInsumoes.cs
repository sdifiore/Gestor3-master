namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsumoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insumoes",
                c => new
                    {
                        InsumoId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 100),
                        UnidadeId = c.Int(nullable: false),
                        TipoId = c.Int(nullable: false),
                        ClasseCustoId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        FamiliaId = c.Int(nullable: false),
                        LinhaId = c.Int(nullable: false),
                        Peso = c.Single(nullable: false),
                        QuantidadeCusto = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                        FinalidadeId = c.Int(nullable: false),
                        UnddId = c.Int(nullable: false),
                        QtdUnddConsumo = c.Single(nullable: false),
                        QtdMltplCompra = c.Single(nullable: false),
                        Unidade_UnidadeId = c.Int(),
                    })
                .PrimaryKey(t => t.InsumoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.ClasseCustoes", t => t.ClasseCustoId, cascadeDelete: true)
                .ForeignKey("dbo.Familias", t => t.FamiliaId, cascadeDelete: true)
                .ForeignKey("dbo.Finalidades", t => t.FinalidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Linhas", t => t.LinhaId, cascadeDelete: true)
                .ForeignKey("dbo.Tipoes", t => t.TipoId, cascadeDelete: true)
                .ForeignKey("dbo.Unidades", t => t.Unidade_UnidadeId)
                .ForeignKey("dbo.Unidades", t => t.UnddId, cascadeDelete: true)
                .Index(t => t.TipoId)
                .Index(t => t.ClasseCustoId)
                .Index(t => t.CategoriaId)
                .Index(t => t.FamiliaId)
                .Index(t => t.LinhaId)
                .Index(t => t.FinalidadeId)
                .Index(t => t.UnddId)
                .Index(t => t.Unidade_UnidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades");
            DropForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Insumoes", new[] { "Unidade_UnidadeId" });
            DropIndex("dbo.Insumoes", new[] { "UnddId" });
            DropIndex("dbo.Insumoes", new[] { "FinalidadeId" });
            DropIndex("dbo.Insumoes", new[] { "LinhaId" });
            DropIndex("dbo.Insumoes", new[] { "FamiliaId" });
            DropIndex("dbo.Insumoes", new[] { "CategoriaId" });
            DropIndex("dbo.Insumoes", new[] { "ClasseCustoId" });
            DropIndex("dbo.Insumoes", new[] { "TipoId" });
            DropTable("dbo.Insumoes");
        }
    }
}
