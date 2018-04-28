namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRefAnoToPlanejVendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "RefAno", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "RefAno");
        }
    }
}
