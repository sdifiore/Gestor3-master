namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDintRevestToEncapTubos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EncapTuboes", "DintRevest", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EncapTuboes", "DintRevest");
        }
    }
}
