namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoFieldsToMemoriaTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memorias", "AtualizacaoCargos", c => c.DateTime(nullable: false));
            AddColumn("dbo.Memorias", "AtualizacaoDespFixas", c => c.DateTime(nullable: false));
            AddColumn("dbo.Memorias", "AtualizacaoFatHistorico", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memorias", "AtualizacaoFatHistorico");
            DropColumn("dbo.Memorias", "AtualizacaoDespFixas");
            DropColumn("dbo.Memorias", "AtualizacaoCargos");
        }
    }
}
