namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecificIdToProdutoesDemoteApelidoAsField : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Produtoes");
            AddColumn("dbo.Produtoes", "Apelido", c => c.String(maxLength: 10));
            AlterColumn("dbo.Produtoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Produtoes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Produtoes");
            AlterColumn("dbo.Produtoes", "Id", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Produtoes", "Apelido");
            AddPrimaryKey("dbo.Produtoes", "Id");
        }
    }
}
