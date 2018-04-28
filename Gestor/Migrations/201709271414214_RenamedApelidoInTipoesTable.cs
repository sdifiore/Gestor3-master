namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedApelidoInTipoesTable : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Tipoes.Type', 'Apelido', 'COLUMN'");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tipoes", "Type", c => c.String(maxLength: 1));
            DropColumn("dbo.Tipoes", "Apelido");
        }
    }
}
