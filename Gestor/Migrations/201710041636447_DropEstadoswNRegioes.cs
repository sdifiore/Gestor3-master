namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEstadoswNRegioes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estadoes", "Regiao_RegiaoId", "dbo.Regiaos");
            DropIndex("dbo.Estadoes", new[] { "Regiao_RegiaoId" });
            DropTable("dbo.Estadoes");
            DropTable("dbo.Regiaos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Regiaos",
                c => new
                    {
                        RegiaoId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 2),
                        Descricao = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.RegiaoId);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Estadoes", "Regiao_RegiaoId");
            AddForeignKey("dbo.Estadoes", "Regiao_RegiaoId", "dbo.Regiaos", "RegiaoId");
        }
    }
}
