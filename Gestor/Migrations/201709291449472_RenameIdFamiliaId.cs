namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdFamiliaId : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Familias.Id', 'FamiliaId'");
        }
        
        public override void Down()
        {
            Sql("sp_rename 'Familias.FamiliaId', 'Id'");
        }
    }
}
