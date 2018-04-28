namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnidadesFinally : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('cx', 'caixa')");
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('pc', 'pe�a')");
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('kg', 'kilograma')");
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('mt', 'metro')");
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('rl', 'rolo')");
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('ml', 'milheiro')");
        }
        
        public override void Down()
        {
        }
    }
}
