namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateClasseCustoes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.ClasseCustoes (Apelido, Descricao) Values ('00', 'Mercadoria para Revenda')");
            Sql("Insert Into dbo.ClasseCustoes (Apelido, Descricao) Values ('01', 'Matéria-Prima')");
            Sql("Insert Into dbo.ClasseCustoes (Apelido, Descricao) Values ('02', 'Embalagem')");
            Sql("Insert Into dbo.ClasseCustoes (Apelido, Descricao) Values ('06', 'Produto Intermediário')");
            Sql("Insert Into dbo.ClasseCustoes (Apelido, Descricao) Values ('07', 'Material de Uso e Consumo')");
            Sql("Insert Into dbo.ClasseCustoes (Apelido, Descricao) Values ('10', 'Outros Insumos')");
        }
        
        public override void Down()
        {
        }
    }
}
