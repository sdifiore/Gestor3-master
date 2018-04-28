namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnidadesToAjuste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ajustes", "UnidadeDeId", c => c.Int(nullable: false));
            AddColumn("dbo.Ajustes", "UnidadeParaId", c => c.Int(nullable: false));
            AddColumn("dbo.Ajustes", "UnidadeDe_UnidadeId", c => c.Int());
            AddColumn("dbo.Ajustes", "UnidadePara_UnidadeId", c => c.Int());
            CreateIndex("dbo.Ajustes", "UnidadeDe_UnidadeId");
            CreateIndex("dbo.Ajustes", "UnidadePara_UnidadeId");
            AddForeignKey("dbo.Ajustes", "UnidadeDe_UnidadeId", "dbo.Unidades", "UnidadeId");
            AddForeignKey("dbo.Ajustes", "UnidadePara_UnidadeId", "dbo.Unidades", "UnidadeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ajustes", "UnidadePara_UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Ajustes", "UnidadeDe_UnidadeId", "dbo.Unidades");
            DropIndex("dbo.Ajustes", new[] { "UnidadePara_UnidadeId" });
            DropIndex("dbo.Ajustes", new[] { "UnidadeDe_UnidadeId" });
            DropColumn("dbo.Ajustes", "UnidadePara_UnidadeId");
            DropColumn("dbo.Ajustes", "UnidadeDe_UnidadeId");
            DropColumn("dbo.Ajustes", "UnidadeParaId");
            DropColumn("dbo.Ajustes", "UnidadeDeId");
        }
    }
}
