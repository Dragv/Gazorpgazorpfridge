namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Last_Migration_Maybe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductForCanastas", "CantidadMaxima", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductForCanastas", "CantidadMaxima");
        }
    }
}
