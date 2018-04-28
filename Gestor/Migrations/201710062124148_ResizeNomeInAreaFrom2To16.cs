namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResizeNomeInAreaFrom2To16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Areas", "Nome", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Areas", "Nome", c => c.String(maxLength: 2));
        }
    }
}
