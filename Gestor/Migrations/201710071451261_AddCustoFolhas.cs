namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustoFolhas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustoFolhas",
                c => new
                    {
                        CustoFolhaId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Salario = c.Single(nullable: false),
                        Ferias = c.Single(nullable: false),
                        DecimoTerceiro = c.Single(nullable: false),
                        Plr = c.Single(nullable: false),
                        Fgts = c.Single(nullable: false),
                        Inss = c.Single(nullable: false),
                        DespAgencia = c.Single(nullable: false),
                        ConvMedico = c.Single(nullable: false),
                        VAlimentacao = c.Single(nullable: false),
                        VTransporte = c.Single(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustoFolhaId)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustoFolhas", "AreaId", "dbo.Areas");
            DropIndex("dbo.CustoFolhas", new[] { "AreaId" });
            DropTable("dbo.CustoFolhas");
        }
    }
}
