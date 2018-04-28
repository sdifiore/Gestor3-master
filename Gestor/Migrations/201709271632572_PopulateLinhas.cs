namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLinhas : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('1015', 'Firlon MD')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('1021', 'Mexichem-P')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('1024', 'Firlon HD')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('1025', 'Pavco')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('2112', 'Fita empacotamento')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('2113', 'Fita isolante')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('2114', 'Fita demarca��o')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('2115', 'Fita multiuso')");
            Sql("Insert Into dbo.Linhas (Apelido, Descricao) Values ('5011', 'PTFE M�dia RR')");
        }
        
        public override void Down()
        {
        }
    }
}
