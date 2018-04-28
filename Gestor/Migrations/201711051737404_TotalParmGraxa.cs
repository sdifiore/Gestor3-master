namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalParmGraxa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TotalParmGraxas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinHora = c.Single(nullable: false),
                        KgH = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ParmGraxas", "MinHora", c => c.Single());
            DropColumn("dbo.ParmGraxas", "Pesagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParmGraxas", "Pesagem", c => c.Single());
            DropColumn("dbo.ParmGraxas", "MinHora");
            DropTable("dbo.TotalParmGraxas");
        }
    }
}
