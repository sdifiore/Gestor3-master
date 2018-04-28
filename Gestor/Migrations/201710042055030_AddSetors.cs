namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSetors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setors",
                c => new
                    {
                        SetorId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 3),
                        Descricao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.SetorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Setors");
        }
    }
}
