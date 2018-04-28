namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNumeroPedidoInFatHistoricoToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FatHistoricoes", "NumeroPedido", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FatHistoricoes", "NumeroPedido", c => c.Int(nullable: false));
        }
    }
}
