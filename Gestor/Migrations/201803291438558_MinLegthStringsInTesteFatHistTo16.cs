namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinLegthStringsInTesteFatHistTo16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TesteFatHists", "UF", c => c.String(maxLength: 16));
            AlterColumn("dbo.TesteFatHists", "Codigo", c => c.String(maxLength: 16));
            AlterColumn("dbo.TesteFatHists", "CodigoAjustado", c => c.String(maxLength: 16));
            AlterColumn("dbo.TesteFatHists", "Trimestre", c => c.String(maxLength: 16));
            AlterColumn("dbo.TesteFatHists", "PeriodoEstatistico", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TesteFatHists", "PeriodoEstatistico", c => c.String(maxLength: 9));
            AlterColumn("dbo.TesteFatHists", "Trimestre", c => c.String(maxLength: 7));
            AlterColumn("dbo.TesteFatHists", "CodigoAjustado", c => c.String(maxLength: 6));
            AlterColumn("dbo.TesteFatHists", "Codigo", c => c.String(maxLength: 6));
            AlterColumn("dbo.TesteFatHists", "UF", c => c.String(maxLength: 2));
        }
    }
}
