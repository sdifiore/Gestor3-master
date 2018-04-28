namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateRegiaos : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('N', 'Norte')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('Ne', 'Nordeste')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('SE', 'Sudeste')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('S', 'Sul')");
            Sql("Insert Into Regiaos (Apelido, Descricao) Values ('CO', 'Centro-Oeste')");
        }
        
        public override void Down()
        {
        }
    }
}
