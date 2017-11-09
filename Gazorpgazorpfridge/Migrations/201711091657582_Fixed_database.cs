namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed_database : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Refrigeradors", "codigo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Refrigeradors", "codigo", c => c.String());
        }
    }
}
