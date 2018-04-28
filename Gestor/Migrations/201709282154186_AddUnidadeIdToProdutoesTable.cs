namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnidadeIdToProdutoesTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Produtoes", name: "Unidade_Id", newName: "UnidadeId");
            RenameIndex(table: "dbo.Produtoes", name: "IX_Unidade_Id", newName: "IX_UnidadeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Produtoes", name: "IX_UnidadeId", newName: "IX_Unidade_Id");
            RenameColumn(table: "dbo.Produtoes", name: "UnidadeId", newName: "Unidade_Id");
        }
    }
}
