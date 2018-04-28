namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DespesasExportacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DespesaExportacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 3),
                        Valor = c.Single(nullable: false),
                        Descricao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DespesaExportacaos");
        }
    }
}
