namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubstituteUnidadeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ClasseCusto_Id", "dbo.ClasseCustoes");
            DropForeignKey("dbo.Products", "Tipo_Id", "dbo.Tipoes");
            DropForeignKey("dbo.Products", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Products", new[] { "ClasseCusto_Id" });
            DropIndex("dbo.Products", new[] { "Tipo_Id" });
            DropIndex("dbo.Products", new[] { "Unit_Id" });
            DropPrimaryKey("dbo.Products");
           // AddColumn("dbo.Products", "CategoriaApelido", c => c.String(maxLength: 2));
           // AlterColumn("dbo.Products", "Id", c => c.String(nullable: false, maxLength: 128));
          //  AddPrimaryKey("dbo.Products", "Id");
            DropColumn("dbo.Products", "Categoria");
            DropColumn("dbo.Products", "ClasseCusto_Id");
            DropColumn("dbo.Products", "Tipo_Id");
            DropColumn("dbo.Products", "Unit_Id");
            DropTable("dbo.Units");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 2),
                        Description = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Unit_Id", c => c.Int());
            AddColumn("dbo.Products", "Tipo_Id", c => c.Int());
            AddColumn("dbo.Products", "ClasseCusto_Id", c => c.Int());
            AddColumn("dbo.Products", "Categoria", c => c.String(maxLength: 2));
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Products", "CategoriaApelido");
            AddPrimaryKey("dbo.Products", "Id");
            CreateIndex("dbo.Products", "Unit_Id");
            CreateIndex("dbo.Products", "Tipo_Id");
            CreateIndex("dbo.Products", "ClasseCusto_Id");
            AddForeignKey("dbo.Products", "Unit_Id", "dbo.Units", "Id");
            AddForeignKey("dbo.Products", "Tipo_Id", "dbo.Tipoes", "Id");
            AddForeignKey("dbo.Products", "ClasseCusto_Id", "dbo.ClasseCustoes", "Id");
        }
    }
}
