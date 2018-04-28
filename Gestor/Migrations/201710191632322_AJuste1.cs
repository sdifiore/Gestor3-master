namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AJuste1 : DbMigration
    {
        public override void Up()
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
                        IdCmpnt = c.String(),
                        PdrHoraria = c.Single(nullable: false),
                        ProdComp = c.Single(nullable: false),
                        CstMtrlDrt = c.Single(nullable: false),
                        CstMtrlPrcd1 = c.Single(nullable: false),
                        CstMtrlPrcd2 = c.Single(nullable: false),
                        CstMtrlPrcd3 = c.Single(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalheEstruturaId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalheEstruturas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.DetalheEstruturas", new[] { "ProdutoId" });
            DropTable("dbo.DetalheEstruturas");
        }
    }
}
