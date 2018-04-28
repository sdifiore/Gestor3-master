namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstruturaDACPlanilhaJaneiroMarcelo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Estruturas", "FamiliaId", c => c.Int(nullable: false));
            AddColumn("dbo.Estruturas", "LinhaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Estruturas", "IdProd", c => c.String(maxLength: 256));
            AlterColumn("dbo.Estruturas", "IdCmpnt", c => c.String(maxLength: 256));
            CreateIndex("dbo.Estruturas", "CategoriaId");
            CreateIndex("dbo.Estruturas", "FamiliaId");
            CreateIndex("dbo.Estruturas", "LinhaId");
            AddForeignKey("dbo.Estruturas", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: false);
            AddForeignKey("dbo.Estruturas", "FamiliaId", "dbo.Familias", "FamiliaId", cascadeDelete: false);
            AddForeignKey("dbo.Estruturas", "LinhaId", "dbo.Linhas", "LinhaId", cascadeDelete: false);
            DropColumn("dbo.Estruturas", "Linha");
            DropColumn("dbo.Estruturas", "Categoria");
            DropColumn("dbo.Estruturas", "Familia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estruturas", "Familia", c => c.String(maxLength: 128));
            AddColumn("dbo.Estruturas", "Categoria", c => c.String(maxLength: 128));
            AddColumn("dbo.Estruturas", "Linha", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Estruturas", "LinhaId", "dbo.Linhas");
            DropForeignKey("dbo.Estruturas", "FamiliaId", "dbo.Familias");
            DropForeignKey("dbo.Estruturas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Estruturas", new[] { "LinhaId" });
            DropIndex("dbo.Estruturas", new[] { "FamiliaId" });
            DropIndex("dbo.Estruturas", new[] { "CategoriaId" });
            AlterColumn("dbo.Estruturas", "IdCmpnt", c => c.String());
            AlterColumn("dbo.Estruturas", "IdProd", c => c.String());
            DropColumn("dbo.Estruturas", "LinhaId");
            DropColumn("dbo.Estruturas", "FamiliaId");
            DropColumn("dbo.Estruturas", "CategoriaId");
        }
    }
}
