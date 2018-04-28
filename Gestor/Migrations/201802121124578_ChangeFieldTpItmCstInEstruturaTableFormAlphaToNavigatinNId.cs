namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldTpItmCstInEstruturaTableFormAlphaToNavigatinNId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "TpItmCstId", c => c.Int(nullable: false));
            AddColumn("dbo.Estruturas", "TpItmCst_TipoId", c => c.Int());
            CreateIndex("dbo.Estruturas", "TpItmCst_TipoId");
            AddForeignKey("dbo.Estruturas", "TpItmCst_TipoId", "dbo.Tipoes", "TipoId");
            DropColumn("dbo.Estruturas", "TpItmCst");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estruturas", "TpItmCst", c => c.String());
            DropForeignKey("dbo.Estruturas", "TpItmCst_TipoId", "dbo.Tipoes");
            DropIndex("dbo.Estruturas", new[] { "TpItmCst_TipoId" });
            DropColumn("dbo.Estruturas", "TpItmCst_TipoId");
            DropColumn("dbo.Estruturas", "TpItmCstId");
        }
    }
}
