namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStringsTo128BytesInPrecoNacionalTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrecoNacionals", "LinhaUn", c => c.String(maxLength: 128));
            AlterColumn("dbo.PrecoNacionals", "Descricao", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrecoNacionals", "Descricao", c => c.String(maxLength: 64));
            AlterColumn("dbo.PrecoNacionals", "LinhaUn", c => c.String(maxLength: 16));
        }
    }
}
