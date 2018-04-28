namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdProdToDetalheEstrutura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalheEstruturas", "IdProd", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalheEstruturas", "IdProd");
        }
    }
}
