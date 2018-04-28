namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropProcesses : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Processes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Processes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoOperacao = c.String(maxLength: 10),
                        Setor = c.String(maxLength: 3),
                        Descricao = c.String(),
                        TaxaOcupacao = c.Single(nullable: false),
                        Comentario = c.String(),
                        QuantidadeMaquinas = c.Int(nullable: false),
                        CustoHora = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
