namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateSequencias : DbMigration
    {
        public override void Up()
        {
            Sql("Delete From Sequencias");
        }
        
        public override void Down()
        {
        }
    }
}
