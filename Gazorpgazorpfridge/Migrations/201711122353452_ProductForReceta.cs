namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductForReceta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductForRecetas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recetaId = c.Int(nullable: false),
                        productoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Productos", t => t.productoId, cascadeDelete: true)
                .ForeignKey("dbo.Recetas", t => t.recetaId, cascadeDelete: true)
                .Index(t => t.recetaId)
                .Index(t => t.productoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductForRecetas", "recetaId", "dbo.Recetas");
            DropForeignKey("dbo.ProductForRecetas", "productoId", "dbo.Productos");
            DropIndex("dbo.ProductForRecetas", new[] { "productoId" });
            DropIndex("dbo.ProductForRecetas", new[] { "recetaId" });
            DropTable("dbo.ProductForRecetas");
        }
    }
}
