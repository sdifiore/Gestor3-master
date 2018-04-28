namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstruturaDeAcordoComNovaPlanilhaMarcelo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "CustoIndividual", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "RefAuxiliarProduto", c => c.String(maxLength: 16));
            AddColumn("dbo.Estruturas", "TipoItemCusto", c => c.String(maxLength: 128));
            AddColumn("dbo.Estruturas", "Linha", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estruturas", "Linha");
            DropColumn("dbo.Estruturas", "TipoItemCusto");
            DropColumn("dbo.Estruturas", "RefAuxiliarProduto");
            DropColumn("dbo.Estruturas", "CustoIndividual");
        }
    }
}
