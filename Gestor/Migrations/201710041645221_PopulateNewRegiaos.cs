namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewRegiaos : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('100', 'SP/Capital')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('210', 'SP/Baixada')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('250', 'SP/Interior')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('400', 'Sudeste')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('500', 'Centro-Oeste')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('600', 'Nordeste')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('700', 'Norte')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('900', 'Exterior')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('000', 'Indefinida')");
        }

        public override void Down()
        {
        }
    }
}
