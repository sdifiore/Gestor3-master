namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSequencia : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Sequencias.Apelido', 'Descricao'");
            Sql("Insert Into dbo.Sequencias (Descricao) Values ('A')");
            Sql("Insert Into dbo.Sequencias (Descricao) Values ('B')");
            Sql("Insert Into dbo.Sequencias (Descricao) Values ('C')");
            Sql("Insert Into dbo.Sequencias (Descricao) Values ('D')");
            Sql("Insert Into dbo.Sequencias (Descricao) Values ('E1')");
            Sql("Insert Into dbo.Sequencias (Descricao) Values ('E2')");
            Sql("Insert Into dbo.Sequencias (Descricao) Values ('F')");
        }
        
        public override void Down()
        {
        }
    }
}
