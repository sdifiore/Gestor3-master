namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstoquesToFloatInPlanejCompras : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlanejCompras", "EstoqueMinimo", c => c.Single(nullable: false));
            AlterColumn("dbo.PlanejCompras", "EstoqueInicial", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlanejCompras", "EstoqueInicial", c => c.Int(nullable: false));
            AlterColumn("dbo.PlanejCompras", "EstoqueMinimo", c => c.Int(nullable: false));
        }
    }
}
