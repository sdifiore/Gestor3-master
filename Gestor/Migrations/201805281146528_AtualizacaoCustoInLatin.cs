namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoCustoInLatin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memorias", "AlualizacaoCustos", c => c.DateTime(nullable: false));
            DropColumn("dbo.Memorias", "AlualizaçãoCustos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Memorias", "AlualizaçãoCustos", c => c.DateTime(nullable: false));
            DropColumn("dbo.Memorias", "AlualizacaoCustos");
        }
    }
}
