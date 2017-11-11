namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whyamigrationforeverypull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paquetes", "caducidad", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paquetes", "caducidad", c => c.String());
        }
    }
}
