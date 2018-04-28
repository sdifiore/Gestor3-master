namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedProductsColumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Código", newName: "Codigo");
            RenameColumn(table: "dbo.Products", name: "Descrição", newName: "Descricao");
            RenameColumn(table: "dbo.Products", name: "Classe de Custo", newName: "ClasseCusto");
            RenameColumn(table: "dbo.Products", name: "Família", newName: "Familia");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Products", name: "Familia", newName: "Família");
            RenameColumn(table: "dbo.Products", name: "ClasseCusto", newName: "Classe de Custo");
            RenameColumn(table: "dbo.Products", name: "Descricao", newName: "Descrição");
            RenameColumn(table: "dbo.Products", name: "Codigo", newName: "Código");
        }
    }
}
