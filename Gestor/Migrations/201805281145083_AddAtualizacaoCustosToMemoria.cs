namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAtualizacaoCustosToMemoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memorias", "AlualizaçãoCustos", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memorias", "AlualizaçãoCustos");
        }
    }
}
