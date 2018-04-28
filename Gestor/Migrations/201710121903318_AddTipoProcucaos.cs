namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoProcucaos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoProducaos",
                c => new
                    {
                        TipoProducaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.TipoProducaoId);
            
            Sql("Insert into dbo.TipoProducaos (Descricao) Values('IND')");
            Sql("Insert into dbo.TipoProducaos (Descricao) Values('BEN')");
        }

        public override void Down()
        {
            DropTable("dbo.TipoProducaos");
        }
    }
}
