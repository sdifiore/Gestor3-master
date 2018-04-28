namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DACMarceloJaneiro2018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "DescricaoUnidade", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "DescricaoUnidade");
        }
    }
}
