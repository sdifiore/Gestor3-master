namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinLegthStringsInCuboTrabalhadoTo6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CubosTrabalhados", "UF", c => c.String(maxLength: 16));
            AlterColumn("dbo.CubosTrabalhados", "Codigo", c => c.String(maxLength: 16));
            AlterColumn("dbo.CubosTrabalhados", "CodigoAjustado", c => c.String(maxLength: 16));
            AlterColumn("dbo.CubosTrabalhados", "Trimestre", c => c.String(maxLength: 16));
            AlterColumn("dbo.CubosTrabalhados", "PeriodoEstatistico", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CubosTrabalhados", "PeriodoEstatistico", c => c.String(maxLength: 9));
            AlterColumn("dbo.CubosTrabalhados", "Trimestre", c => c.String(maxLength: 7));
            AlterColumn("dbo.CubosTrabalhados", "CodigoAjustado", c => c.String(maxLength: 6));
            AlterColumn("dbo.CubosTrabalhados", "Codigo", c => c.String(maxLength: 6));
            AlterColumn("dbo.CubosTrabalhados", "UF", c => c.String(maxLength: 2));
        }
    }
}
