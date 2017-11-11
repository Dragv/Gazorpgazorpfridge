namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refrimodelrestriction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Refrigeradores", "codigo", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Refrigeradores", "codigo", c => c.String(nullable: false));
        }
    }
}
