namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQtdMaquinas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QtdMaquinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Linha = c.String(maxLength: 8),
                        Descricao = c.String(maxLength: 100),
                        QuantidadeMaquinas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Produtoes", "PesoBruto", c => c.Single(nullable: false));
            DropColumn("dbo.Produtoes", "Peso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Peso", c => c.Single(nullable: false));
            DropColumn("dbo.Produtoes", "PesoBruto");
            DropTable("dbo.QtdMaquinas");
        }
    }
}
