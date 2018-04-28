namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateGrupoRateiosWithLowerCase : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('fita')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('graxa')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('gxfpuro')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('revenda')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('tubo')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('sucata')");
            Sql("Insert Into dbo.GrupoRateios (Descricao) Values('descarte')");
        }
        
        public override void Down()
        {
        }
    }
}
