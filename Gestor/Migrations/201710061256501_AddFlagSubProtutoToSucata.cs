namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlagSubProtutoToSucata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sucatas", "SubProduto", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sucatas", "SubProduto");
        }
    }
}
