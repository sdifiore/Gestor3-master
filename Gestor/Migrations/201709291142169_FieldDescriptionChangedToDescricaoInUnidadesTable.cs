namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldDescriptionChangedToDescricaoInUnidadesTable : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Unidades", "Description", c => c.String(maxLength: 16));
            DropColumn("dbo.Unidades", "Descricao");
        }
    }
}
