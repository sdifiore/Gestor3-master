namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation1ClasseCustoNProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ClasseCustoApelido", c => c.String(maxLength: 2));
            AddColumn("dbo.Products", "ClasseCusto_Id", c => c.Int());
            CreateIndex("dbo.Products", "ClasseCusto_Id");
            AddForeignKey("dbo.Products", "ClasseCusto_Id", "dbo.ClasseCustoes", "Id");
            DropColumn("dbo.Products", "ClasseCusto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ClasseCusto", c => c.String(maxLength: 2));
            DropForeignKey("dbo.Products", "ClasseCusto_Id", "dbo.ClasseCustoes");
            DropIndex("dbo.Products", new[] { "ClasseCusto_Id" });
            DropColumn("dbo.Products", "ClasseCusto_Id");
            DropColumn("dbo.Products", "ClasseCustoApelido");
        }
    }
}
