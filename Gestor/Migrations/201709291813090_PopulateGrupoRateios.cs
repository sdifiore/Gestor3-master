namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGrupoRateios : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('FITA')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('GRAXA')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('GRAXA')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('GXFPURO')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('REVENDA')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('TUBO')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('SUCATA')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('DESCARTE')");
        }
        
        public override void Down()
        {
        }
    }
}
