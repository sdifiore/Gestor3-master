namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeEstuturaBeFullSpreaqdsheet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estruturas", "UnidadeId", "dbo.Unidades");
            DropIndex("dbo.Estruturas", new[] { "UnidadeId" });
            AddColumn("dbo.Estruturas", "DescCompProc", c => c.String(maxLength: 256));
            AddColumn("dbo.Estruturas", "CustoUnitCompra", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "PartCusto", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "QtEftvUntrCmpnt", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "CstCmprUndPrd", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "TpItmCst", c => c.String());
            AddColumn("dbo.Estruturas", "AlrtSbPrdt", c => c.String());
            AddColumn("dbo.Estruturas", "TempMaq", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "QtdUndd", c => c.Int(nullable: false));
            AddColumn("dbo.Estruturas", "PsLiqdFnl", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "PsLiqdPrcdt", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "HrsModFnl", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "HrsModPrec1", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "HrsModPrec2", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "IdProd", c => c.String());
            AddColumn("dbo.Estruturas", "IdCmpnt", c => c.String());
            AddColumn("dbo.Estruturas", "PdrHoraria", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "ProdComp", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "CstIndividual", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "CstMtrlDrt", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "CstMtrlPrcd1", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "CstMtrlPrcd2", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "CstMtrlPrcd3", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Header", c => c.Boolean(nullable: false));
            AddColumn("dbo.Estruturas", "Unidade_UnidadeId", c => c.Int());
            AddColumn("dbo.Estruturas", "UnidadeCompra_UnidadeId", c => c.Int());
            CreateIndex("dbo.Estruturas", "Unidade_UnidadeId");
            CreateIndex("dbo.Estruturas", "UnidadeCompra_UnidadeId");
            AddForeignKey("dbo.Estruturas", "UnidadeCompra_UnidadeId", "dbo.Unidades", "UnidadeId");
            AddForeignKey("dbo.Estruturas", "Unidade_UnidadeId", "dbo.Unidades", "UnidadeId");
            DropColumn("dbo.Estruturas", "Apelido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estruturas", "Apelido", c => c.String(maxLength: 10));
            DropForeignKey("dbo.Estruturas", "Unidade_UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Estruturas", "UnidadeCompra_UnidadeId", "dbo.Unidades");
            DropIndex("dbo.Estruturas", new[] { "UnidadeCompra_UnidadeId" });
            DropIndex("dbo.Estruturas", new[] { "Unidade_UnidadeId" });
            DropColumn("dbo.Estruturas", "UnidadeCompra_UnidadeId");
            DropColumn("dbo.Estruturas", "Unidade_UnidadeId");
            DropColumn("dbo.Estruturas", "Header");
            DropColumn("dbo.Estruturas", "CstMtrlPrcd3");
            DropColumn("dbo.Estruturas", "CstMtrlPrcd2");
            DropColumn("dbo.Estruturas", "CstMtrlPrcd1");
            DropColumn("dbo.Estruturas", "CstMtrlDrt");
            DropColumn("dbo.Estruturas", "CstIndividual");
            DropColumn("dbo.Estruturas", "ProdComp");
            DropColumn("dbo.Estruturas", "PdrHoraria");
            DropColumn("dbo.Estruturas", "IdCmpnt");
            DropColumn("dbo.Estruturas", "IdProd");
            DropColumn("dbo.Estruturas", "HrsModPrec2");
            DropColumn("dbo.Estruturas", "HrsModPrec1");
            DropColumn("dbo.Estruturas", "HrsModFnl");
            DropColumn("dbo.Estruturas", "PsLiqdPrcdt");
            DropColumn("dbo.Estruturas", "PsLiqdFnl");
            DropColumn("dbo.Estruturas", "QtdUndd");
            DropColumn("dbo.Estruturas", "TempMaq");
            DropColumn("dbo.Estruturas", "AlrtSbPrdt");
            DropColumn("dbo.Estruturas", "TpItmCst");
            DropColumn("dbo.Estruturas", "CstCmprUndPrd");
            DropColumn("dbo.Estruturas", "QtEftvUntrCmpnt");
            DropColumn("dbo.Estruturas", "PartCusto");
            DropColumn("dbo.Estruturas", "CustoUnitCompra");
            DropColumn("dbo.Estruturas", "DescCompProc");
            CreateIndex("dbo.Estruturas", "UnidadeId");
            AddForeignKey("dbo.Estruturas", "UnidadeId", "dbo.Unidades", "UnidadeId", cascadeDelete: true);
        }
    }
}
