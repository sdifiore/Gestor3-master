namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefAnoNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlanejVendas", "RefAno", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlanejVendas", "RefAno", c => c.DateTime());
        }
    }
}
