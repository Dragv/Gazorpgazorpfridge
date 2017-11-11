namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelomodelrestriction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modelos", "codigo", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modelos", "codigo", c => c.String(nullable: false));
        }
    }
}
