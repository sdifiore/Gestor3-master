namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrazoRecebMedioNacFieldToPlanejVendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanejVendas", "PrazoRecebMedioNac", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanejVendas", "PrazoRecebMedioNac");
        }
    }
}
