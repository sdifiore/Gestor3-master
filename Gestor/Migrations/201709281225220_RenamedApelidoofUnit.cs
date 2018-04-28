namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedApelidoofUnit : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Units.Unidade', 'Apelido', 'COLUMN'");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "Unidade", c => c.String(maxLength: 2));
            DropColumn("dbo.Units", "Apelido");
        }
    }
}
