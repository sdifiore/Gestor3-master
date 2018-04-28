namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResizeDescricaoInRegiaosTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Regiaos", "Descricao", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regiaos", "Descricao", c => c.String(maxLength: 8));
        }
    }
}
