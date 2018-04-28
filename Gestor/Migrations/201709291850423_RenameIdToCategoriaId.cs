namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdToCategoriaId : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Categorias.Id', 'CategoriaId'");
        }
        
        public override void Down()
        {
            Sql("sp_rename 'Categorias.CategoriaId', 'Id'");
        }
    }
}
