namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class misteriousmigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Refrigeradores", new[] { "ApplicationUser_Id" });
            CreateIndex("dbo.Refrigeradores", "applicationUser_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Refrigeradores", new[] { "applicationUser_id" });
            CreateIndex("dbo.Refrigeradores", "ApplicationUser_Id");
        }
    }
}
