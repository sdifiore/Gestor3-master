namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewSequencias : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Sequencias.Desc', 'Descricao'");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('A', 'Mat�ria Prima do processo')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('B', 'Outros insumos e/ou servi�os')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('C', 'Materiais de consumo diversos')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('D', 'Sub produtos')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('E1', 'Opera��o principal fabrica��o produto. Op Mistura � E2 p/ tubos e cord�es. Nos demais � E1')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('E2', 'Opera��o secund�ria da fabrica��o do produto')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('F','Custos n�o operacionais')");
        }

        public override void Down()
        {
            Sql("Delete from Sequencias");
        }
    }
}
