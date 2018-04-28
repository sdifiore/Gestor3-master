namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldSemanasReposicaoToParametros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parametroes", "SemanasReposicao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parametroes", "SemanasReposicao");
        }
    }
}
