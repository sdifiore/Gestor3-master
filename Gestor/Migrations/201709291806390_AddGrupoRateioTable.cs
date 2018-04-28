namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGrupoRateioTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoRateios",
                c => new
                    {
                        GrupoRateioId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.GrupoRateioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrupoRateios");
        }
    }
}
