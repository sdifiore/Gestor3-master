namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation1TipoNProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnidadeApelido", c => c.String(maxLength: 10));
            AddColumn("dbo.Products", "TipoApelido", c => c.String(maxLength: 1));
            AddColumn("dbo.Products", "Tipo_Id", c => c.Int());
            CreateIndex("dbo.Products", "Tipo_Id");
            AddForeignKey("dbo.Products", "Tipo_Id", "dbo.Tipoes", "Id");
            DropColumn("dbo.Products", "Unidade");
            DropColumn("dbo.Products", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Tipo", c => c.String(maxLength: 1));
            AddColumn("dbo.Products", "Unidade", c => c.String(maxLength: 10));
            DropForeignKey("dbo.Products", "Tipo_Id", "dbo.Tipoes");
            DropIndex("dbo.Products", new[] { "Tipo_Id" });
            DropColumn("dbo.Products", "Tipo_Id");
            DropColumn("dbo.Products", "TipoApelido");
            DropColumn("dbo.Products", "UnidadeApelido");
        }
    }
}
