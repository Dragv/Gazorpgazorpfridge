namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed_User : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "canastaBasica_id", "dbo.Recetas");
            DropIndex("dbo.AspNetUsers", new[] { "canastaBasica_id" });
            DropColumn("dbo.AspNetUsers", "canastaBasica_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "canastaBasica_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "canastaBasica_id");
            AddForeignKey("dbo.AspNetUsers", "canastaBasica_id", "dbo.Recetas", "id");
        }
    }
}
