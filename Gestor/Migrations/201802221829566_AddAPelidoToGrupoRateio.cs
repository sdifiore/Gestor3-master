namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAPelidoToGrupoRateio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GrupoRateios", "Apelido", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GrupoRateios", "Apelido");
        }
    }
}
