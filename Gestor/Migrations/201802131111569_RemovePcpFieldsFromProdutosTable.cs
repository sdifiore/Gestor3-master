namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePcpFieldsFromProdutosTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "PcpId", "dbo.Pcps");
            DropIndex("dbo.Produtoes", new[] { "PcpId" });
            DropColumn("dbo.Produtoes", "PcpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "PcpId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "PcpId");
            AddForeignKey("dbo.Produtoes", "PcpId", "dbo.Pcps", "PcpId", cascadeDelete: true);
        }
    }
}
