namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('20', 'Produtos Revenda')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('50', 'Matéria Prima PTFE')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('51', 'Matérias Primas Secundárias')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('52', 'Insumo Semi Acabado')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('60', 'Embalagens')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('61', 'Mats de Acondicionamento')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('71', 'Outros consumíveis prod.')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('82', 'Outros consumíveis não prod')");
            Sql("Insert Into dbo.Categorias (Apelido, Descricao) Values ('91', 'Serviços de Terceiros')");
        }
        
        public override void Down()
        {
        }
    }
}
