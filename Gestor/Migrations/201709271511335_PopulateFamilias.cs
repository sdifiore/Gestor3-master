namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFamilias : DbMigration
    {
        public override void Up()
        {
            
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('201', 'Fitas Adesivas')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('501', 'Fine Powder')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('502', 'Micro Pó')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('503', 'Outros PTFEs')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('511', 'Aditivos e Pigmentos')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('512', 'Outras Matérias Primas')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('601', 'Cartuchos')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('602', 'Caixxas de Papelão')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('606', 'Etiquetas e Rótulos')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('607', 'Outros Mats. Embalagem')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('610', 'Anéis')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('611', 'Carretéis')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('613', 'Matéria Prima para Anéis e Carretéis')");
        }
        
        public override void Down()
        {
        }
    }
}
