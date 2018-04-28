namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoWithLinkToRegiao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoUf = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 20),
                        Uf = c.String(maxLength: 2),
                        RegiaId = c.Int(nullable: false),
                        Regiao_RegiaoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regiaos", t => t.Regiao_RegiaoId)
                .Index(t => t.Regiao_RegiaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estadoes", "Regiao_RegiaoId", "dbo.Regiaos");
            DropIndex("dbo.Estadoes", new[] { "Regiao_RegiaoId" });
            DropTable("dbo.Estadoes");
        }
    }
}
