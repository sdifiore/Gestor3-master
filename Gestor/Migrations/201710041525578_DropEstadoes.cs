namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEstadoes : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Estadoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoUf = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 20),
                        Uf = c.String(maxLength: 2),
                        Regiao = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
