namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrecosNacionais : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrecoNacionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinhaUn = c.String(maxLength: 16),
                        Descricao = c.String(maxLength: 64),
                        Apelido = c.String(maxLength: 10),
                        Ipi = c.Single(nullable: false),
                        QtUnid = c.Int(nullable: false),
                        TipoProducaoId = c.Int(nullable: false),
                        I18Nivel1 = c.Single(nullable: false),
                        I18Nivel2 = c.Single(nullable: false),
                        I18Nivel3 = c.Single(nullable: false),
                        I12Nivel1 = c.Single(nullable: false),
                        I12Nivel2 = c.Single(nullable: false),
                        I12Nivel3 = c.Single(nullable: false),
                        I7Nivel1 = c.Single(nullable: false),
                        I7Nivel2 = c.Single(nullable: false),
                        I7Nivel3 = c.Single(nullable: false),
                        Com = c.Single(nullable: false),
                        LlMin = c.Single(nullable: false),
                        PrecoRefer = c.Single(nullable: false),
                        AplicRoteiro = c.Single(nullable: false),
                        CustoDireto = c.Single(nullable: false),
                        RateioCustoFixo = c.Single(nullable: false),
                        Aumento = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoProducaos", t => t.TipoProducaoId, cascadeDelete: true)
                .Index(t => t.TipoProducaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrecoNacionals", "TipoProducaoId", "dbo.TipoProducaos");
            DropIndex("dbo.PrecoNacionals", new[] { "TipoProducaoId" });
            DropTable("dbo.PrecoNacionals");
        }
    }
}
