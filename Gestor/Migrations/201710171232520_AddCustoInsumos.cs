namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustoInsumos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustoInsumoes",
                c => new
                    {
                        CustoInsumoId = c.Int(nullable: false, identity: true),
                        PrcBrtCmpr = c.Single(nullable: false),
                        CrdtIcms = c.Single(nullable: false),
                        CrdtIpi = c.Single(nullable: false),
                        CrdtPis = c.Single(nullable: false),
                        CrdtCofins = c.Single(nullable: false),
                        SumCrdtImpostos = c.Single(nullable: false),
                        DespImport = c.Single(nullable: false),
                        CustoExtra = c.Single(nullable: false),
                        CstUndConsumo = c.Single(nullable: false),
                        FgmtoFornecImport = c.Single(nullable: false),
                        UsoStrut = c.Single(nullable: false),
                        ExisteRede = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustoInsumoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustoInsumoes");
        }
    }
}
