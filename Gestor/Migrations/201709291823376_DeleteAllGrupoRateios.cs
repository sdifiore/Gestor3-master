namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllGrupoRateios : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from GrupoRateios");
        }
        
        public override void Down()
        {
        }
    }
}
