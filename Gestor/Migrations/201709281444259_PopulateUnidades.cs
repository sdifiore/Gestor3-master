namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUnidades : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Unidades.Description', 'Descricao', 'COLUMN'");
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('cx', 'caixa')");
            Sql("Insert Into dbo.Unidades (Id, Descricao) Values ('pc', 'peça')");
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
