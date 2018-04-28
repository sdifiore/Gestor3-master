namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PadraoFixos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PadraoFixoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 128),
                        Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PadraoFixoes");
        }
    }
}
