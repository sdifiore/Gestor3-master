namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefANoInPlanejVendasAsDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlanejVendas", "RefAno", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlanejVendas", "RefAno", c => c.String(maxLength: 7));
        }
    }
}
