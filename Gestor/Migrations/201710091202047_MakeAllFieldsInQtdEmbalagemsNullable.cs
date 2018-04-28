namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeAllFieldsInQtdEmbalagemsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QtdEmbalagems", "CartuchoRolCx", c => c.Int());
            AlterColumn("dbo.QtdEmbalagems", "CartuchoCxPlt", c => c.Int());
            AlterColumn("dbo.QtdEmbalagems", "CarretelRolCx", c => c.Int());
            AlterColumn("dbo.QtdEmbalagems", "CarretelCxPlt", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QtdEmbalagems", "CarretelCxPlt", c => c.Int(nullable: false));
            AlterColumn("dbo.QtdEmbalagems", "CarretelRolCx", c => c.Int(nullable: false));
            AlterColumn("dbo.QtdEmbalagems", "CartuchoCxPlt", c => c.Int(nullable: false));
            AlterColumn("dbo.QtdEmbalagems", "CartuchoRolCx", c => c.Int(nullable: false));
        }
    }
}
