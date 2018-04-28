namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropUnidadesTable : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Produtoes", "UnidadeId", "dbo.Unidades");
            //DropIndex("dbo.Produtoes", new[] { "UnidadeId" });
            //DropTable("dbo.Unidades");

            // Tabela apagada manualmente <<<<< ------------------------------
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Unidades",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 2),
                        Descricao = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Produtoes", "UnidadeId");
            AddForeignKey("dbo.Produtoes", "UnidadeId", "dbo.Unidades", "Id");
        }
    }
}
