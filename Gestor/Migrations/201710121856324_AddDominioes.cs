namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDominioes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dominios",
                c => new
                    {
                        DominioId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.DominioId);
            
            Sql("Insert into dbo.Dominios (Descricao) Values ('Próprio')");
            Sql("Insert into dbo.Dominios (Descricao) Values ('Terceiros')");
            Sql("Insert into dbo.Dominios (Descricao) Values ('Interno')");
        }

        public override void Down()
        {
            DropTable("dbo.Dominios");
        }
    }
}
