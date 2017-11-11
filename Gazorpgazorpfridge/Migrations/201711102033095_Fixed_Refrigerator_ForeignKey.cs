namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed_Refrigerator_ForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recetas", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Refrigeradores", "applicationUser_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recetas", "ApplicationUser_Id");
            CreateIndex("dbo.Refrigeradores", "applicationUser_id");
            AddForeignKey("dbo.Recetas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Refrigeradores", "applicationUser_id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Refrigeradores", "applicationUser_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recetas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Refrigeradores", new[] { "applicationUser_id" });
            DropIndex("dbo.Recetas", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Refrigeradores", "applicationUser_id");
            DropColumn("dbo.Recetas", "ApplicationUser_Id");
        }
    }
}
