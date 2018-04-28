namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldsWithEstoqueToFloatInPlanejProducao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlanejProducaos", "EstoqueReposicao", c => c.Single(nullable: false));
            AlterColumn("dbo.PlanejProducaos", "Estoque", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlanejProducaos", "Estoque", c => c.Int(nullable: false));
            AlterColumn("dbo.PlanejProducaos", "EstoqueReposicao", c => c.Int(nullable: false));
        }
    }
}
