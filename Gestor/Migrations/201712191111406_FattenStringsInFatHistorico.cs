namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FattenStringsInFatHistorico : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FatHistoricoes", "NumeroPedido", c => c.String(maxLength: 32));
            AlterColumn("dbo.FatHistoricoes", "Cliente", c => c.String(maxLength: 256));
            AlterColumn("dbo.FatHistoricoes", "Estado", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "Cidade", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "Regiao", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "Vendedor", c => c.String(maxLength: 256));
            AlterColumn("dbo.FatHistoricoes", "FormaPagamento", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "TipoVenda", c => c.String(maxLength: 16));
            AlterColumn("dbo.FatHistoricoes", "MesCadastro", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "AnoMesFatura", c => c.String(maxLength: 16));
            AlterColumn("dbo.FatHistoricoes", "Situacao", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "MesEntrega", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "ClientePedido", c => c.String(maxLength: 1024));
            AlterColumn("dbo.FatHistoricoes", "NaturCli", c => c.String(maxLength: 8));
            AlterColumn("dbo.FatHistoricoes", "TipoCliente", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "CategoriaCliente", c => c.String(maxLength: 128));
            AlterColumn("dbo.FatHistoricoes", "SegmentoCliente", c => c.String(maxLength: 128));
            AlterColumn("dbo.FatHistoricoes", "Grupo", c => c.String(maxLength: 512));
            AlterColumn("dbo.FatHistoricoes", "DescrProdAjustado", c => c.String(maxLength: 512));
            AlterColumn("dbo.FatHistoricoes", "ProdCategoriaAjustado", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FatHistoricoes", "ProdCategoriaAjustado", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "DescrProdAjustado", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "Grupo", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "SegmentoCliente", c => c.String(maxLength: 32));
            AlterColumn("dbo.FatHistoricoes", "CategoriaCliente", c => c.String(maxLength: 32));
            AlterColumn("dbo.FatHistoricoes", "TipoCliente", c => c.String(maxLength: 10));
            AlterColumn("dbo.FatHistoricoes", "NaturCli", c => c.String(maxLength: 1));
            AlterColumn("dbo.FatHistoricoes", "ClientePedido", c => c.String(maxLength: 128));
            AlterColumn("dbo.FatHistoricoes", "MesEntrega", c => c.String(maxLength: 7));
            AlterColumn("dbo.FatHistoricoes", "Situacao", c => c.String(maxLength: 16));
            AlterColumn("dbo.FatHistoricoes", "AnoMesFatura", c => c.String(maxLength: 7));
            AlterColumn("dbo.FatHistoricoes", "MesCadastro", c => c.String(maxLength: 7));
            AlterColumn("dbo.FatHistoricoes", "TipoVenda", c => c.String(maxLength: 3));
            AlterColumn("dbo.FatHistoricoes", "FormaPagamento", c => c.String(maxLength: 16));
            AlterColumn("dbo.FatHistoricoes", "Vendedor", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "Regiao", c => c.String(maxLength: 24));
            AlterColumn("dbo.FatHistoricoes", "Cidade", c => c.String(maxLength: 32));
            AlterColumn("dbo.FatHistoricoes", "Estado", c => c.String(maxLength: 24));
            AlterColumn("dbo.FatHistoricoes", "Cliente", c => c.String(maxLength: 64));
            AlterColumn("dbo.FatHistoricoes", "NumeroPedido", c => c.String(maxLength: 16));
        }
    }
}
