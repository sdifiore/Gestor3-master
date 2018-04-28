namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameToPctDespExportEspecInPrecoExportacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrecoExportacaos", "PctDespExportEspec", c => c.Single(nullable: false));
            DropColumn("dbo.PrecoExportacaos", "PdtDespExportEspec");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrecoExportacaos", "PdtDespExportEspec", c => c.Single(nullable: false));
            DropColumn("dbo.PrecoExportacaos", "PctDespExportEspec");
        }
    }
}
