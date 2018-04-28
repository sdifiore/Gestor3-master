namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdToClasseCustoId : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'ClasseCustoes.Id', 'ClasseCustoId'");
        }
        
        public override void Down()
        {
            Sql("sp_rename 'ClasseCustoes.ClasseCustoId', 'Id'");
        }
    }
}
