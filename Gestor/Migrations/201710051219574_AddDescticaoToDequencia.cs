namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescticaoToDequencia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sequencias", "Tipo", c => c.String(maxLength: 2));
            AlterColumn("dbo.Sequencias", "Descricao", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sequencias", "Descricao", c => c.String(maxLength: 2));
            DropColumn("dbo.Sequencias", "Tipo");
        }
    }
}
