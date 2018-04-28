namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegioesComCodigodeRegiao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regiaos",
                c => new
                    {
                        RegiaoId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 3),
                        Descricao = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.RegiaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regiaos");
        }
    }
}
