namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSequencias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sequencias", "Desc", c => c.String(maxLength: 100));
            DropColumn("dbo.Sequencias", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sequencias", "Descricao", c => c.String(maxLength: 100));
            DropColumn("dbo.Sequencias", "Desc");
        }
    }
}
