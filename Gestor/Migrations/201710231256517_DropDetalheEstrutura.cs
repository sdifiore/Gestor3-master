namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDetalheEstrutura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalheEstruturas", "EstruturaId", "dbo.Estruturas");
            DropIndex("dbo.DetalheEstruturas", new[] { "EstruturaId" });
            DropTable("dbo.DetalheEstruturas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DetalheEstruturas",
                c => new
                    {
                        DetalheEstruturaId = c.Int(nullable: false, identity: true),
                        PartCusto = c.Single(nullable: false),
                        QtEftvUntrCmpnt = c.Single(nullable: false),
                        CstCmprUndPrd = c.Single(nullable: false),
                        TpItmCst = c.String(),
                        AlrtSbPrdt = c.String(),
                        TempMaq = c.Single(nullable: false),
                        QtdUndd = c.Int(nullable: false),
                        PsLiqdFnl = c.Single(nullable: false),
                        PsLiqdPrcdt = c.Single(nullable: false),
                        HrsModFnl = c.Single(nullable: false),
                        HrsModPrec1 = c.Single(nullable: false),
                        HrsModPrec2 = c.Single(nullable: false),
                        IdProd = c.String(),
                        IdCmpnt = c.String(),
                        PdrHoraria = c.Single(nullable: false),
                        ProdComp = c.Single(nullable: false),
                        CstMtrlDrt = c.Single(nullable: false),
                        CstMtrlPrcd1 = c.Single(nullable: false),
                        CstMtrlPrcd2 = c.Single(nullable: false),
                        CstMtrlPrcd3 = c.Single(nullable: false),
                        Header = c.Boolean(nullable: false),
                        EstruturaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalheEstruturaId);
            
            CreateIndex("dbo.DetalheEstruturas", "EstruturaId");
            AddForeignKey("dbo.DetalheEstruturas", "EstruturaId", "dbo.Estruturas", "Id", cascadeDelete: true);
        }
    }
}
