namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkUnidadeCompraToUnidadesInEstrutura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "UnidadeCompraId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estruturas", "UnidadeCompraId");
        }
    }
}
