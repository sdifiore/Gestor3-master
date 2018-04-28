namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewSequencias : DbMigration
    {
        public override void Up()
        {
            Sql("sp_rename 'Sequencias.Desc', 'Descricao'");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('A', 'Matéria Prima do processo')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('B', 'Outros insumos e/ou serviços')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('C', 'Materiais de consumo diversos')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('D', 'Sub produtos')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('E1', 'Operação principal fabricação produto. Op Mistura é E2 p/ tubos e cordões. Nos demais é E1')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('E2', 'Operação secundária da fabricação do produto')");
            Sql("Insert into dbo.Sequencias (Tipo, Descricao) Values ('F','Custos não operacionais')");
        }

        public override void Down()
        {
            Sql("Delete from Sequencias");
        }
    }
}
