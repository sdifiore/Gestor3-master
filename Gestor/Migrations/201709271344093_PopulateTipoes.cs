namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTipoes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Tipoes (Type, Descricao) Values('a', 'Manufaturado')");
            Sql("Insert Into dbo.Tipoes (Type, Descricao) Values('b', 'Insumos/Matérias-Primas')");
        }
        
        public override void Down()
        {
        }
    }
}
