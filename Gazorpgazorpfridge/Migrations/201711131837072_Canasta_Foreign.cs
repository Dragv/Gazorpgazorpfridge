namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Canasta_Foreign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CanastasBasicas", "CanastaBasica_id", c => c.Int());
            CreateIndex("dbo.CanastasBasicas", "CanastaBasica_id");
            AddForeignKey("dbo.CanastasBasicas", "CanastaBasica_id", "dbo.CanastasBasicas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CanastasBasicas", "CanastaBasica_id", "dbo.CanastasBasicas");
            DropIndex("dbo.CanastasBasicas", new[] { "CanastaBasica_id" });
            DropColumn("dbo.CanastasBasicas", "CanastaBasica_id");
        }
    }
}
