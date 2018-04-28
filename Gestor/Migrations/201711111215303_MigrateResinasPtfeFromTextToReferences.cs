namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateResinasPtfeFromTextToReferences : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResinaPtfes", "FabricanteId", c => c.Int(nullable: false));
            AddColumn("dbo.ResinaPtfes", "InsumoId", c => c.Int(nullable: false));
            CreateIndex("dbo.ResinaPtfes", "FabricanteId");
            CreateIndex("dbo.ResinaPtfes", "InsumoId");
            AddForeignKey("dbo.ResinaPtfes", "FabricanteId", "dbo.Fabricantes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResinaPtfes", "InsumoId", "dbo.Insumoes", "InsumoId", cascadeDelete: true);
            DropColumn("dbo.ResinaPtfes", "Fabricante");
            DropColumn("dbo.ResinaPtfes", "Apelido");
            DropColumn("dbo.ResinaPtfes", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResinaPtfes", "Descricao", c => c.String(maxLength: 128));
            AddColumn("dbo.ResinaPtfes", "Apelido", c => c.String(maxLength: 10));
            AddColumn("dbo.ResinaPtfes", "Fabricante", c => c.String(maxLength: 32));
            DropForeignKey("dbo.ResinaPtfes", "InsumoId", "dbo.Insumoes");
            DropForeignKey("dbo.ResinaPtfes", "FabricanteId", "dbo.Fabricantes");
            DropIndex("dbo.ResinaPtfes", new[] { "InsumoId" });
            DropIndex("dbo.ResinaPtfes", new[] { "FabricanteId" });
            DropColumn("dbo.ResinaPtfes", "InsumoId");
            DropColumn("dbo.ResinaPtfes", "FabricanteId");
        }
    }
}
