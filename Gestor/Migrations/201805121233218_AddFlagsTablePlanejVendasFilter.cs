namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlagsTablePlanejVendasFilter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanejVendasFilters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanejVendasFilters");
        }
    }
}
