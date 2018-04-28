namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameRegiaIdToRegiaoIdInEstaoes : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Estadoes.RegiaId', 'RegiaoId'");
        }
        
        public override void Down()
        {
            Sql("sp_rename 'Estadoes.RegiaoId', 'RegiaId'");
        }
    }
}
