namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldProdCategoriaAjustadoInFatHistoricoTo64char : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FatHistoricoes", "ProdCategoriaAjustado", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FatHistoricoes", "ProdCategoriaAjustado", c => c.String(maxLength: 16));
        }
    }
}
