namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RenameBaseTableAsComum : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'dbo.Bases', Comums");
        }

        public override void Down()
        {
            Sql("sp_rename 'dbo.Comums', Bases");
        }
    }
}
