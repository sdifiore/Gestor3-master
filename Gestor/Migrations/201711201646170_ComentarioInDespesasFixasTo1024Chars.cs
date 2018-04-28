namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComentarioInDespesasFixasTo1024Chars : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DespesaFixas", "Comentario", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DespesaFixas", "Comentario", c => c.String(maxLength: 128));
        }
    }
}
