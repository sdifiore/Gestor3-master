namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnknownChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estruturas", "TpItmCst_TipoId", "dbo.Tipoes");
            DropIndex("dbo.Estruturas", new[] { "TpItmCst_TipoId" });
            AddColumn("dbo.Estruturas", "TpItmCst", c => c.String());
            DropColumn("dbo.Estruturas", "TpItmCstId");
            DropColumn("dbo.Estruturas", "TpItmCst_TipoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estruturas", "TpItmCst_TipoId", c => c.Int());
            AddColumn("dbo.Estruturas", "TpItmCstId", c => c.Int(nullable: false));
            DropColumn("dbo.Estruturas", "TpItmCst");
            CreateIndex("dbo.Estruturas", "TpItmCst_TipoId");
            AddForeignKey("dbo.Estruturas", "TpItmCst_TipoId", "dbo.Tipoes", "TipoId");
        }
    }
}
