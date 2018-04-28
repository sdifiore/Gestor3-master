namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullCuboEstoque : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CuboEstoques", "Descricao", c => c.String(maxLength: 256));
            AddColumn("dbo.CuboEstoques", "ClasseCusto", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CuboEstoques", "ClasseCusto");
            DropColumn("dbo.CuboEstoques", "Descricao");
        }
    }
}
