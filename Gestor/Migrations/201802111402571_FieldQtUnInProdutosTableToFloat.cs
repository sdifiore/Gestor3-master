namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldQtUnInProdutosTableToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtoes", "QtdUnid", c => c.Single(nullable: false));
            AlterColumn("dbo.Estruturas", "QtdUndd", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estruturas", "QtdUndd", c => c.Int(nullable: false));
            AlterColumn("dbo.Produtoes", "QtdUnid", c => c.Int(nullable: false));
        }
    }
}
