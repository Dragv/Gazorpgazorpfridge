namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ref_Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Refrigeradores", "micanasta_id", "dbo.CanastasBasicas");
            DropIndex("dbo.Refrigeradores", new[] { "micanasta_id" });
            DropColumn("dbo.Refrigeradores", "micanasta_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Refrigeradores", "micanasta_id", c => c.Int());
            CreateIndex("dbo.Refrigeradores", "micanasta_id");
            AddForeignKey("dbo.Refrigeradores", "micanasta_id", "dbo.CanastasBasicas", "id");
        }
    }
}
