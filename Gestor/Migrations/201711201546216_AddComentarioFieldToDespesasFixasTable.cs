namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComentarioFieldToDespesasFixasTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DespesaFixas", "Comentario", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DespesaFixas", "Comentario");
        }
    }
}
