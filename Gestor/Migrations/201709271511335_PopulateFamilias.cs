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
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('502', 'Micro P�')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('503', 'Outros PTFEs')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('511', 'Aditivos e Pigmentos')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('512', 'Outras Mat�rias Primas')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('601', 'Cartuchos')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('602', 'Caixxas de Papel�o')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('606', 'Etiquetas e R�tulos')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('607', 'Outros Mats. Embalagem')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('610', 'An�is')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('611', 'Carret�is')");
            Sql("Insert Into dbo.Familias (Apelido, Descricao) Values ('613', 'Mat�ria Prima para An�is e Carret�is')");
        }
        
        public override void Down()
        {
        }
    }
}
