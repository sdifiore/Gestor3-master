namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumSetorProducaoInCustoCargoDireto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustoCargoDiretoes", "SetorProducao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustoCargoDiretoes", "SetorProducao", c => c.String(maxLength: 32));
        }
    }
}
