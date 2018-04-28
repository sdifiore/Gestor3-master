namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFierdToUnidadeConsumoIdInInsumos : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Insumoes", name: "UnddId", newName: "UnidadeConsumoId");
            RenameIndex(table: "dbo.Insumoes", name: "IX_UnddId", newName: "IX_UnidadeConsumoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Insumoes", name: "IX_UnidadeConsumoId", newName: "IX_UnddId");
            RenameColumn(table: "dbo.Insumoes", name: "UnidadeConsumoId", newName: "UnddId");
        }
    }
}
