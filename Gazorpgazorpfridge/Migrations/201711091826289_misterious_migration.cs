namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class misterious_migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "codigo", c => c.String(nullable: false));
            AlterColumn("dbo.Productos", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Productos", "medida", c => c.String(nullable: false));
            AlterColumn("dbo.Modelos", "codigo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modelos", "codigo", c => c.String());
            AlterColumn("dbo.Productos", "medida", c => c.String());
            AlterColumn("dbo.Productos", "nombre", c => c.String());
            AlterColumn("dbo.Productos", "codigo", c => c.String());
        }
    }
}
