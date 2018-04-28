namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdToTipoId : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Tipoes.Id', 'TipoId'");
        }
        
        public override void Down()
        {
            Sql("sp_rename 'Tipoes.TipoId', 'Id'");
        }
    }
}
