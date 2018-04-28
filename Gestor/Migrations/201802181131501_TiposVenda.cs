namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TiposVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposVenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 3),
                        Descricao = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TiposVenda");
        }
    }
}
