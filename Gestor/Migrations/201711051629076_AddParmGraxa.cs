namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParmGraxa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParmGraxas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 64),
                        Pesagem = c.Single(),
                        KgH = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParmGraxas");
        }
    }
}
