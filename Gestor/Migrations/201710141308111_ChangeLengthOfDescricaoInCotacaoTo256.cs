namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthOfDescricaoInCotacaoTo256 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cotacaos", "Descricao", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cotacaos", "Descricao", c => c.String(maxLength: 100));
        }
    }
}
