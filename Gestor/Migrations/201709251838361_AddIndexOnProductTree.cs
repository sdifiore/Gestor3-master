namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexOnProductTree : DbMigration
    {
        public override void Up()
        {
            Sql("Create Index iCodigo on dbo.ProductTrees (Codigo)");
        }
        
        public override void Down()
        {
            Sql("Drop Index iCodigo on dbo.Estrutura");
        }
    }
}
