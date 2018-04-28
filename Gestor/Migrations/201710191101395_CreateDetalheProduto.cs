namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDetalheProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalheProdutoes",
                c => new
                    {
                        DetalheProdutoId = c.Int(nullable: false, identity: true),
                        PesoLiquido = c.Single(nullable: false),
                        ItemStrut = c.Int(nullable: false),
                        CstDirIndd = c.Single(nullable: false),
                        CstMtsUltmEtp = c.Single(nullable: false),
                        CstMtsEtp1 = c.Single(nullable: false),
                        CstMtsEtp2 = c.Single(nullable: false),
                        CstMtsEtp3 = c.Single(nullable: false),
                        CstTotMts = c.Single(nullable: false),
                        CstDirMod = c.Single(nullable: false),
                        HrsMod = c.Single(nullable: false),
                        HrsMod1 = c.Single(nullable: false),
                        HrsMod2 = c.Single(nullable: false),
                        HrsTotMod = c.Single(nullable: false),
                        CpcdProdHrr = c.Single(nullable: false),
                        LoteMin = c.Int(nullable: false),
                        UsoStrut = c.Single(nullable: false),
                        CstDirRgKg = c.Single(nullable: false),
                        RelModCst = c.Single(nullable: false),
                        PctMtrFnl = c.Single(nullable: false),
                        PctMtrEtp1 = c.Single(nullable: false),
                        PctMtrEtp2 = c.Single(nullable: false),
                        PctMtrEtp3 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DetalheProdutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DetalheProdutoes");
        }
    }
}
