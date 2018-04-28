namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteTableDACJaneiro2018 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ajustes", "OrigemId", "dbo.Produtoes");
            DropIndex("dbo.Ajustes", new[] { "OrigemId" });
            AddColumn("dbo.Ajustes", "CodigoOriginal", c => c.String(maxLength: 6));
            AddColumn("dbo.Ajustes", "DescricaoOriginal", c => c.String(maxLength: 128));
            DropColumn("dbo.Ajustes", "OrigemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ajustes", "OrigemId", c => c.Int(nullable: false));
            DropColumn("dbo.Ajustes", "DescricaoOriginal");
            DropColumn("dbo.Ajustes", "CodigoOriginal");
            CreateIndex("dbo.Ajustes", "OrigemId");
            AddForeignKey("dbo.Ajustes", "OrigemId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
