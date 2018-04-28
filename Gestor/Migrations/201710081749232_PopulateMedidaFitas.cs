namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMedidaFitas : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (12, 6)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (12, 12)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (12, 15)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (12, 25)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (12, 50)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (18, 5)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (18, 6)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (18, 12)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (18, 15)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (18, 25)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (18, 50)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (24, 5)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (24, 6)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (24, 12)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (24, 15)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (24, 25)");
            Sql("Insert Into dbo.MedidaFitas (LarguraMm, ComprimentoMetros) Values (24, 50)");

        }

        public override void Down()
        {
        }
    }
}
