namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeaderFlagToDetalheEstrutura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalheEstruturas", "Header", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalheEstruturas", "Header");
        }
    }
}
