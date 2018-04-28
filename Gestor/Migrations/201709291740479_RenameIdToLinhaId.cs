namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdToLinhaId : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Linhas.Id', 'LinhaId'");
        }
        
        public override void Down()
        {
            Sql("sp_rename 'Linhas.LinhaId', 'Id'");
        }
    }
}
