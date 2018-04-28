namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPctPtfePesoToProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "PctPtfePeso", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "PctPtfePeso");
        }
    }
}
