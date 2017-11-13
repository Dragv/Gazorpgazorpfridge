namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oops : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CanastasBasicas", "CanastaBasica_id", "dbo.CanastasBasicas");
            DropIndex("dbo.CanastasBasicas", new[] { "CanastaBasica_id" });
            CreateTable(
                "dbo.ProductForCanastas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        canastaId = c.Int(nullable: false),
                        productoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CanastasBasicas", t => t.canastaId, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.productoId, cascadeDelete: true)
                .Index(t => t.canastaId)
                .Index(t => t.productoId);
            
            DropColumn("dbo.CanastasBasicas", "CanastaBasica_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CanastasBasicas", "CanastaBasica_id", c => c.Int());
            DropForeignKey("dbo.ProductForCanastas", "productoId", "dbo.Productos");
            DropForeignKey("dbo.ProductForCanastas", "canastaId", "dbo.CanastasBasicas");
            DropIndex("dbo.ProductForCanastas", new[] { "productoId" });
            DropIndex("dbo.ProductForCanastas", new[] { "canastaId" });
            DropTable("dbo.ProductForCanastas");
            CreateIndex("dbo.CanastasBasicas", "CanastaBasica_id");
            AddForeignKey("dbo.CanastasBasicas", "CanastaBasica_id", "dbo.CanastasBasicas", "id");
        }
    }
}
