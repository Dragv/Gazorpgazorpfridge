namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Canasta_Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CanastasBasicas", "refriId", c => c.Int(nullable: false));
            CreateIndex("dbo.CanastasBasicas", "refriId");
            AddForeignKey("dbo.CanastasBasicas", "refriId", "dbo.Refrigeradores", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CanastasBasicas", "refriId", "dbo.Refrigeradores");
            DropIndex("dbo.CanastasBasicas", new[] { "refriId" });
            DropColumn("dbo.CanastasBasicas", "refriId");
        }
    }
}
