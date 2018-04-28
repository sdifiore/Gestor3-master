namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovosCamposEmProdutosJaneiro2018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Acoes", c => c.String(maxLength: 128));
            AddColumn("dbo.Produtoes", "EventosAgVendasHistorico", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "Acao", c => c.String(maxLength: 128));
            AddColumn("dbo.Produtoes", "Codigo", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Codigo");
            DropColumn("dbo.Produtoes", "Acao");
            DropColumn("dbo.Produtoes", "EventosAgVendasHistorico");
            DropColumn("dbo.Produtoes", "Acoes");
        }
    }
}
