namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UncorrectFieldInParmGraxas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParmGraxas", "Pesagem", c => c.Single());
            DropColumn("dbo.ParmGraxas", "MinHora");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParmGraxas", "MinHora", c => c.Single());
            DropColumn("dbo.ParmGraxas", "Pesagem");
        }
    }
}
