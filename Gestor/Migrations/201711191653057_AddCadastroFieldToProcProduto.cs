namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCadastroFieldToProcProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcTuboes", "Cadastro", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcTuboes", "Cadastro");
        }
    }
}
