namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissingFieldsPlanejProducao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejProducaos", "UnUArm", c => c.Int(nullable: false));
            AddColumn("dbo.PlanejProducaos", "EstoqueReposicao", c => c.Int(nullable: false));
            AddColumn("dbo.PlanejProducaos", "TipoPcp", c => c.String(maxLength: 3));
            AddColumn("dbo.PlanejProducaos", "Estoque", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejProducaos", "Estoque");
            DropColumn("dbo.PlanejProducaos", "TipoPcp");
            DropColumn("dbo.PlanejProducaos", "EstoqueReposicao");
            DropColumn("dbo.PlanejProducaos", "UnUArm");
        }
    }
}
