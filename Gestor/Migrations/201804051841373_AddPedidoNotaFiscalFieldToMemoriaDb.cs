namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPedidoNotaFiscalFieldToMemoriaDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memorias", "PedidoNotaFiscal", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memorias", "PedidoNotaFiscal");
        }
    }
}
