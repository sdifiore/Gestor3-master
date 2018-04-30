namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageInLogDataIlimitedChars : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogData", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogData", "Message", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
