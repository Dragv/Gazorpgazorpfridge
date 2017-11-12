namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_user_reference_to_receta : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Recetas", new[] { "ApplicationUser_Id" });
            CreateIndex("dbo.Recetas", "applicationUser_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Recetas", new[] { "applicationUser_id" });
            CreateIndex("dbo.Recetas", "ApplicationUser_Id");
        }
    }
}
