namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnidadeToProdutoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Unidade_Id", c => c.String(maxLength: 2));
            CreateIndex("dbo.Produtoes", "Unidade_Id");
            AddForeignKey("dbo.Produtoes", "Unidade_Id", "dbo.Unidades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Unidade_Id", "dbo.Unidades");
            DropIndex("dbo.Produtoes", new[] { "Unidade_Id" });
            DropColumn("dbo.Produtoes", "Unidade_Id");
        }
    }
}
