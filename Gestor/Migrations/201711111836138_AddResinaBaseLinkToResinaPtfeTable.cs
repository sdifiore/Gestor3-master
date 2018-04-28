namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResinaBaseLinkToResinaPtfeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResinaPtfes", "ResinaBaseId", c => c.Int(nullable: false));
            CreateIndex("dbo.ResinaPtfes", "ResinaBaseId");
            AddForeignKey("dbo.ResinaPtfes", "ResinaBaseId", "dbo.ResinaBases", "Id", cascadeDelete: true);
            DropColumn("dbo.ResinaPtfes", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResinaPtfes", "Tipo", c => c.String(maxLength: 16));
            DropForeignKey("dbo.ResinaPtfes", "ResinaBaseId", "dbo.ResinaBases");
            DropIndex("dbo.ResinaPtfes", new[] { "ResinaBaseId" });
            DropColumn("dbo.ResinaPtfes", "ResinaBaseId");
        }
    }
}
