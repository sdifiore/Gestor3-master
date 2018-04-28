namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCotacaoToStringInInsumoXtd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InsumoXtds", "CotacaoId", "dbo.Cotacaos");
            DropIndex("dbo.InsumoXtds", new[] { "CotacaoId" });
            AddColumn("dbo.InsumoXtds", "Cotacao", c => c.String(maxLength: 256));
            DropColumn("dbo.InsumoXtds", "CotacaoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InsumoXtds", "CotacaoId", c => c.Int(nullable: false));
            DropColumn("dbo.InsumoXtds", "Cotacao");
            CreateIndex("dbo.InsumoXtds", "CotacaoId");
            AddForeignKey("dbo.InsumoXtds", "CotacaoId", "dbo.Cotacaos", "CotacaoId", cascadeDelete: true);
        }
    }
}
