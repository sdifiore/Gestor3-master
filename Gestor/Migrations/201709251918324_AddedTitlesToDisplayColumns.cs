namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitlesToDisplayColumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Codigo", newName: "Código");
            RenameColumn(table: "dbo.Products", name: "Descricao", newName: "Descrição");
            RenameColumn(table: "dbo.Products", name: "ClasseCusto", newName: "Classe de Custo");
            RenameColumn(table: "dbo.Products", name: "Familia", newName: "Família");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Products", name: "Família", newName: "Familia");
            RenameColumn(table: "dbo.Products", name: "Classe de Custo", newName: "ClasseCusto");
            RenameColumn(table: "dbo.Products", name: "Descrição", newName: "Descricao");
            RenameColumn(table: "dbo.Products", name: "Código", newName: "Codigo");
        }
    }
}
