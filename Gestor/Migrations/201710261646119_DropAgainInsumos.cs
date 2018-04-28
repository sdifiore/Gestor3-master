namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAgainInsumos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comums", "InsumoViewModel_Id", "dbo.InsumoViewModels");
            DropForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades");
            DropForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes");
            DropForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades");
            DropForeignKey("dbo.Insumoes", "InsumoViewModel_Id", "dbo.InsumoViewModels");
            DropForeignKey("dbo.InsumoXtds", "InsumoViewModel_Id", "dbo.InsumoViewModels");
            DropIndex("dbo.Comums", new[] { "InsumoViewModel_Id" });
            DropIndex("dbo.Insumoes", new[] { "TipoId" });
            DropIndex("dbo.Insumoes", new[] { "ClasseCustoId" });
            DropIndex("dbo.Insumoes", new[] { "CategoriaId" });
            DropIndex("dbo.Insumoes", new[] { "FamiliaId" });
            DropIndex("dbo.Insumoes", new[] { "LinhaId" });
            DropIndex("dbo.Insumoes", new[] { "FinalidadeId" });
            DropIndex("dbo.Insumoes", new[] { "UnddId" });
            DropIndex("dbo.Insumoes", new[] { "Unidade_UnidadeId" });
            DropIndex("dbo.Insumoes", new[] { "InsumoViewModel_Id" });
            DropIndex("dbo.InsumoXtds", new[] { "InsumoViewModel_Id" });
            //DropColumn("dbo.Comums", "InsumoViewModel_Id");
            //DropColumn("dbo.InsumoXtds", "InsumoViewModel_Id");
            DropTable("dbo.InsumoViewModels");
            DropTable("dbo.Insumoes");
        }
        
        public override void Down()
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
                        Cotacao = c.String(maxLength: 1024),
                        PrecoUsd = c.Single(nullable: false),
                        PrecoRs = c.Single(nullable: false),
                        Icms = c.Single(nullable: false),
                        Ipi = c.Single(nullable: false),
                        Pis = c.Single(nullable: false),
                        Cofins = c.Single(nullable: false),
                        DespExtra = c.Single(nullable: false),
                        DespImport = c.Single(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        FinalidadeId = c.Int(nullable: false),
                        UnddId = c.Int(nullable: false),
                        QtdUnddConsumo = c.Single(nullable: false),
                        QtdMltplCompra = c.Single(nullable: false),
                        FormaPgto = c.String(maxLength: 16),
                        Prazo1 = c.Int(nullable: false),
                        Prazo2 = c.Int(nullable: false),
                        PctPgto1 = c.Single(nullable: false),
                        ImportPzPagDesp = c.Int(nullable: false),
                        PrcBrtCompra = c.Single(nullable: false),
                        CrdtIcms = c.Single(nullable: false),
                        CrdtIpi = c.Single(nullable: false),
                        CrdtPis = c.Single(nullable: false),
                        CrdtCofins = c.Single(nullable: false),
                        SumCrdImpostos = c.Single(nullable: false),
                        DspImportacao = c.Single(nullable: false),
                        CustoExtra = c.Single(nullable: false),
                        Custo = c.Single(nullable: false),
                        CustoUndCnsm = c.Single(nullable: false),
                        PgtFornecImp = c.Single(nullable: false),
                        UsoStru = c.Int(nullable: false),
                        Unidade_UnidadeId = c.Int(),
                        InsumoViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.InsumoId);
            
            CreateTable(
                "dbo.InsumoViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.InsumoXtds", "InsumoViewModel_Id", c => c.Int());
            AddColumn("dbo.Comums", "InsumoViewModel_Id", c => c.Int());
            CreateIndex("dbo.InsumoXtds", "InsumoViewModel_Id");
            CreateIndex("dbo.Insumoes", "InsumoViewModel_Id");
            CreateIndex("dbo.Insumoes", "Unidade_UnidadeId");
            CreateIndex("dbo.Insumoes", "UnddId");
            CreateIndex("dbo.Insumoes", "FinalidadeId");
            CreateIndex("dbo.Insumoes", "LinhaId");
            CreateIndex("dbo.Insumoes", "FamiliaId");
            CreateIndex("dbo.Insumoes", "CategoriaId");
            CreateIndex("dbo.Insumoes", "ClasseCustoId");
            CreateIndex("dbo.Insumoes", "TipoId");
            CreateIndex("dbo.Comums", "InsumoViewModel_Id");
            AddForeignKey("dbo.InsumoXtds", "InsumoViewModel_Id", "dbo.InsumoViewModels", "Id");
            AddForeignKey("dbo.Insumoes", "InsumoViewModel_Id", "dbo.InsumoViewModels", "Id");
            AddForeignKey("dbo.Insumoes", "UnddId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "Unidade_UnidadeId", "dbo.Unidades", "UnidadeId");
            AddForeignKey("dbo.Insumoes", "TipoId", "dbo.Tipoes", "TipoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "FinalidadeId", "dbo.Finalidades", "FinalidadeId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "ClasseCustoId", "dbo.ClasseCustoes", "ClasseCustoId", cascadeDelete: true);
            AddForeignKey("dbo.Insumoes", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
            AddForeignKey("dbo.Comums", "InsumoViewModel_Id", "dbo.InsumoViewModels", "Id");
        }
    }
}
