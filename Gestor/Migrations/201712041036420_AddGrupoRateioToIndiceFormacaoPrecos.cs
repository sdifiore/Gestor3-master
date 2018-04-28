namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGrupoRateioToIndiceFormacaoPrecos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId", c => c.Int(nullable: false));
            CreateIndex("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId");
            AddForeignKey("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId", "dbo.GrupoRateios", "GrupoRateioId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId", "dbo.GrupoRateios");
            DropIndex("dbo.IndiceRateioFormacaoPrecoVendas", new[] { "GrupoRateioId" });
            DropColumn("dbo.IndiceRateioFormacaoPrecoVendas", "GrupoRateioId");
        }
    }
}
