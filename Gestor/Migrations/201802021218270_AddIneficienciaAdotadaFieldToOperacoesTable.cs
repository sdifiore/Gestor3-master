namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIneficienciaAdotadaFieldToOperacoesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operacaos", "IneficienciaAdotada", c => c.Single(nullable: false));
            AlterColumn("dbo.Operacaos", "Comentario", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Operacaos", "Comentario", c => c.String(maxLength: 100));
            DropColumn("dbo.Operacaos", "IneficienciaAdotada");
        }
    }
}
