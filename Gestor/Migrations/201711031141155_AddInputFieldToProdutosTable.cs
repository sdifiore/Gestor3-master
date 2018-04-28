namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInputFieldToProdutosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Input", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Input");
        }
    }
}
