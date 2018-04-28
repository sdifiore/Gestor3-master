namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCnpjFieldToCuboTrabalhoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CubosTrabalhados", "Cnpj", c => c.String(maxLength: 24));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CubosTrabalhados", "Cnpj");
        }
    }
}
