namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexOnApelidoInProdutoes : DbMigration
    {
        public override void Up()
        {
            Sql("Create unique index iApelido on Produtoes (Apelido)");
        }
        
        public override void Down()
        {
        }
    }
}
