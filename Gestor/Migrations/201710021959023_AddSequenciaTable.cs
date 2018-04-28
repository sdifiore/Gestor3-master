namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSequenciaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sequencias",
                c => new
                    {
                        SequenciaId = c.Int(nullable: false, identity: true),
                        Apelido = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.SequenciaId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Sequencias");
        }
    }
}
