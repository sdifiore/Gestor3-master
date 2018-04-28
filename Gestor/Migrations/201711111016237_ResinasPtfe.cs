namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResinasPtfe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResinaPtfes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ref = c.Int(nullable: false),
                        Referencia = c.String(maxLength: 16),
                        Fabricante = c.String(maxLength: 32),
                        Tipo = c.String(maxLength: 16),
                        Apelido = c.String(maxLength: 10),
                        Descricao = c.String(maxLength: 128),
                        Custo = c.Single(nullable: false),
                        MaxRr = c.Int(nullable: false),
                        Classificacao = c.String(maxLength: 16),
                        MaxRrAntiga = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResinaPtfes");
        }
    }
}
