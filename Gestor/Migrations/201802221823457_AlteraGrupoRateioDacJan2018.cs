namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteraGrupoRateioDacJan2018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GrupoRateios", "Fita", c => c.Single(nullable: false));
            AddColumn("dbo.GrupoRateios", "Tubo", c => c.Single(nullable: false));
            AddColumn("dbo.GrupoRateios", "Fiotec", c => c.Single(nullable: false));
            AddColumn("dbo.GrupoRateios", "Gxpuro", c => c.Single(nullable: false));
            AddColumn("dbo.GrupoRateios", "Gxgraf", c => c.Single(nullable: false));
            AddColumn("dbo.GrupoRateios", "Graxa", c => c.Single(nullable: false));
            AddColumn("dbo.GrupoRateios", "Revenda", c => c.Single(nullable: false));
            AlterColumn("dbo.GrupoRateios", "Descricao", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GrupoRateios", "Descricao", c => c.String(maxLength: 50));
            DropColumn("dbo.GrupoRateios", "Revenda");
            DropColumn("dbo.GrupoRateios", "Graxa");
            DropColumn("dbo.GrupoRateios", "Gxgraf");
            DropColumn("dbo.GrupoRateios", "Gxpuro");
            DropColumn("dbo.GrupoRateios", "Fiotec");
            DropColumn("dbo.GrupoRateios", "Tubo");
            DropColumn("dbo.GrupoRateios", "Fita");
        }
    }
}
