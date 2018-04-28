namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUnidades1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Unidades (Apelido, Descricao) Values ('cx', 'caixa')");
            Sql("Insert Into dbo.Unidades (Apelido, Descricao) Values ('pc', 'peça')");
            Sql("Insert Into dbo.Unidades (Apelido, Descricao) Values ('kg', 'kilograma')");
            Sql("Insert Into dbo.Unidades (Apelido, Descricao) Values ('mt', 'metro')");
            Sql("Insert Into dbo.Unidades (Apelido, Descricao) Values ('rl', 'rolo')");
            Sql("Insert Into dbo.Unidades (Apelido, Descricao) Values ('ml', 'milheiro')");
        }
        
        public override void Down()
        {
        }
    }
}
