namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFamiliasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Familias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 3),
                        Descricao = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Familias");
        }
    }
}
