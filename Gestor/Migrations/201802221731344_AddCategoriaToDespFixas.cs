namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaToDespFixas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DespFixas", "CatDespFixaId", c => c.Int(nullable: false));
            CreateIndex("dbo.DespFixas", "CatDespFixaId");
            AddForeignKey("dbo.DespFixas", "CatDespFixaId", "dbo.CatDespFixas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DespFixas", "CatDespFixaId", "dbo.CatDespFixas");
            DropIndex("dbo.DespFixas", new[] { "CatDespFixaId" });
            DropColumn("dbo.DespFixas", "CatDespFixaId");
        }
    }
}
