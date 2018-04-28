namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoPcpFieldInPlanejProducaoTo32Chars : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlanejProducaos", "TipoPcp", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlanejProducaos", "TipoPcp", c => c.String(maxLength: 3));
        }
    }
}
