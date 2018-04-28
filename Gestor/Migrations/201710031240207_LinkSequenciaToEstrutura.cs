namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkSequenciaToEstrutura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "SequenciaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Estruturas", "SequenciaId");
            AddForeignKey("dbo.Estruturas", "SequenciaId", "dbo.Sequencias", "SequenciaId", cascadeDelete: true);
            DropColumn("dbo.Estruturas", "Sequencia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estruturas", "Sequencia", c => c.String(maxLength: 2));
            DropForeignKey("dbo.Estruturas", "SequenciaId", "dbo.Sequencias");
            DropIndex("dbo.Estruturas", new[] { "SequenciaId" });
            DropColumn("dbo.Estruturas", "SequenciaId");
        }
    }
}
