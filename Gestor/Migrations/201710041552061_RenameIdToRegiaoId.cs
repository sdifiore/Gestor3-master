namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdToRegiaoId : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Regiaos.Id', 'RegiaoId'");
        }
        
        public override void Down()
        {
            Sql("sp_rename 'Regiaos.RegiaoId', 'Id'");
        }
    }
}
