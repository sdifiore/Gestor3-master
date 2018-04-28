namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinalidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Finalidades",
                c => new
                    {
                        FinalidadeId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.FinalidadeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Finalidades");
        }
    }
}
