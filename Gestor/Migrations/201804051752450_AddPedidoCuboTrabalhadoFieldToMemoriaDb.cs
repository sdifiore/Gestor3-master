namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPedidoCuboTrabalhadoFieldToMemoriaDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memorias", "PedidoCuboTrabalhado", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memorias", "PedidoCuboTrabalhado");
        }
    }
}
