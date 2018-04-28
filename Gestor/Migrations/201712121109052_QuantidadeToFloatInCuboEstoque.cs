namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantidadeToFloatInCuboEstoque : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CuboEstoques", "Quantidade", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CuboEstoques", "Quantidade", c => c.Int(nullable: false));
        }
    }
}
