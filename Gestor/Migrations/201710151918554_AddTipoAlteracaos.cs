namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoAlteracaos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoAlteracaos",
                c => new
                    {
                        TipoAlteracaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.TipoAlteracaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoAlteracaos");
        }
    }
}
