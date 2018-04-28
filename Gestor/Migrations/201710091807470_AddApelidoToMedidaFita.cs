namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApelidoToMedidaFita : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedidaFitas", "Apelido", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedidaFitas", "Apelido");
        }
    }
}
