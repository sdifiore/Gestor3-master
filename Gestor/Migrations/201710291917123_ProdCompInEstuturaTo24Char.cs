namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdCompInEstuturaTo24Char : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estruturas", "ProdComp", c => c.String(maxLength: 24));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estruturas", "ProdComp", c => c.String());
        }
    }
}
