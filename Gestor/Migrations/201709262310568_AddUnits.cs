namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnits : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into dbo.Units (Unidade, Description) Values ('cx', 'Caixa')");
            Sql("Insert Into dbo.Units (Unidade, Description) Values ('rl', 'Rolo')");
            Sql("Insert Into dbo.Units (Unidade, Description) Values ('kg', 'Kilograma')");
            Sql("Insert Into dbo.Units (Unidade, Description) Values ('mh', 'Milheiro')");
            Sql("Insert Into dbo.Units (Unidade, Description) Values ('pc', 'Peça')");
        }
        
        public override void Down()
        {
        }
    }
}
