namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPcp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pcps",
                c => new
                    {
                        PcpId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.PcpId);
            Sql("Insert into dbo.Pcps (Descricao) Values ('PE')");
            Sql("Insert into dbo.Pcps (Descricao) Values ('SE')");

        }

        public override void Down()
        {
            DropTable("dbo.Pcps");
        }
    }
}
