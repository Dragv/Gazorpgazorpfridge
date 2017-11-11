namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I_dont_get_this_UML : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paquetes", "refriId", c => c.Int(nullable: false));
            CreateIndex("dbo.Paquetes", "refriId");
            AddForeignKey("dbo.Paquetes", "refriId", "dbo.Refrigeradores", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paquetes", "refriId", "dbo.Refrigeradores");
            DropIndex("dbo.Paquetes", new[] { "refriId" });
            DropColumn("dbo.Paquetes", "refriId");
        }
    }
}
