namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CanastaBasicas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        perEscasez = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nombre = c.String(),
                        espacioVol = c.Single(nullable: false),
                        medida = c.String(),
                        CanastaBasica_id = c.Int(),
                        Receta_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CanastaBasicas", t => t.CanastaBasica_id)
                .ForeignKey("dbo.Recetas", t => t.Receta_id)
                .Index(t => t.CanastaBasica_id)
                .Index(t => t.Receta_id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        capacidad = c.Single(nullable: false),
                        indiceEnfriamiento = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Paquetes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        caducidad = c.String(),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Productoes", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Refrigeradors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        capacidad = c.Int(nullable: false),
                        indiceDeEnfriamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.AspNetUsers", "name", c => c.String());
            AddColumn("dbo.AspNetUsers", "canastaBasica_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "canastaBasica_id");
            AddForeignKey("dbo.AspNetUsers", "canastaBasica_id", "dbo.Recetas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "canastaBasica_id", "dbo.Recetas");
            DropForeignKey("dbo.Productoes", "Receta_id", "dbo.Recetas");
            DropForeignKey("dbo.Paquetes", "productId", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "CanastaBasica_id", "dbo.CanastaBasicas");
            DropIndex("dbo.AspNetUsers", new[] { "canastaBasica_id" });
            DropIndex("dbo.Paquetes", new[] { "productId" });
            DropIndex("dbo.Productoes", new[] { "Receta_id" });
            DropIndex("dbo.Productoes", new[] { "CanastaBasica_id" });
            DropColumn("dbo.AspNetUsers", "canastaBasica_id");
            DropColumn("dbo.AspNetUsers", "name");
            DropTable("dbo.Refrigeradors");
            DropTable("dbo.Recetas");
            DropTable("dbo.Paquetes");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Productoes");
            DropTable("dbo.CanastaBasicas");
        }
    }
}
