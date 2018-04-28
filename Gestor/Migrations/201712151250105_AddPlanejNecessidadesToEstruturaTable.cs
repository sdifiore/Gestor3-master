namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanejNecessidadesToEstruturaTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estruturas", "SetorProducao", c => c.String(maxLength: 128));
            AddColumn("dbo.Estruturas", "Categoria", c => c.String(maxLength: 128));
            AddColumn("dbo.Estruturas", "Familia", c => c.String(maxLength: 128));
            AddColumn("dbo.Estruturas", "ListaPlanejProducao", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "NeedComponProducao", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "ListaNecessProdNivel1", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "NecCompListaP1", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "ListaNecessProdNivel2", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "NecCompListaP2", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "ListaNecessProdNivel3", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "NecCompListaP3", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "ListaNecessProdNivel4", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "NecCompListaP4", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "NecTotalComponente", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes1", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes2", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes3", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes4", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes5", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes6", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes7", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes8", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes9", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes10", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes11", c => c.Single(nullable: false));
            AddColumn("dbo.Estruturas", "Mes12", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estruturas", "Mes12");
            DropColumn("dbo.Estruturas", "Mes11");
            DropColumn("dbo.Estruturas", "Mes10");
            DropColumn("dbo.Estruturas", "Mes9");
            DropColumn("dbo.Estruturas", "Mes8");
            DropColumn("dbo.Estruturas", "Mes7");
            DropColumn("dbo.Estruturas", "Mes6");
            DropColumn("dbo.Estruturas", "Mes5");
            DropColumn("dbo.Estruturas", "Mes4");
            DropColumn("dbo.Estruturas", "Mes3");
            DropColumn("dbo.Estruturas", "Mes2");
            DropColumn("dbo.Estruturas", "Mes1");
            DropColumn("dbo.Estruturas", "NecTotalComponente");
            DropColumn("dbo.Estruturas", "NecCompListaP4");
            DropColumn("dbo.Estruturas", "ListaNecessProdNivel4");
            DropColumn("dbo.Estruturas", "NecCompListaP3");
            DropColumn("dbo.Estruturas", "ListaNecessProdNivel3");
            DropColumn("dbo.Estruturas", "NecCompListaP2");
            DropColumn("dbo.Estruturas", "ListaNecessProdNivel2");
            DropColumn("dbo.Estruturas", "NecCompListaP1");
            DropColumn("dbo.Estruturas", "ListaNecessProdNivel1");
            DropColumn("dbo.Estruturas", "NeedComponProducao");
            DropColumn("dbo.Estruturas", "ListaPlanejProducao");
            DropColumn("dbo.Estruturas", "Familia");
            DropColumn("dbo.Estruturas", "Categoria");
            DropColumn("dbo.Estruturas", "SetorProducao");
        }
    }
}
