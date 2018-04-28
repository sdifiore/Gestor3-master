namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUnidadesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Unidades",
                c => new
                    {
                        UnidadeId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 2),
                        Descricao = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.UnidadeId);
            
           // DropColumn("dbo.Produtoes", "UnidadeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "UnidadeId", c => c.String(maxLength: 2));
            DropTable("dbo.Unidades");
        }
    }
}
