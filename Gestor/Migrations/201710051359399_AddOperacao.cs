namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOperacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operacaos",
                c => new
                    {
                        OperacaoId = c.Int(nullable: false, identity: true),
                        CodigoOperacao = c.String(maxLength: 10),
                        SetorProducao = c.String(maxLength: 100),
                        Descricao = c.String(maxLength: 100),
                        TaxaOcupacao = c.Single(nullable: false),
                        Comentario = c.String(maxLength: 100),
                        QtdMaquinas = c.Int(nullable: false),
                        Custo = c.Single(nullable: false),
                        SetorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OperacaoId)
                .ForeignKey("dbo.Setors", t => t.SetorId, cascadeDelete: true)
                .Index(t => t.SetorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operacaos", "SetorId", "dbo.Setors");
            DropIndex("dbo.Operacaos", new[] { "SetorId" });
            DropTable("dbo.Operacaos");
        }
    }
}
