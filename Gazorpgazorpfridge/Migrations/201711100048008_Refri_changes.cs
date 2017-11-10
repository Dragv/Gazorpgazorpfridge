namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refri_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Refrigeradores", "modeloId", c => c.Int(nullable: false));
            AddColumn("dbo.Refrigeradores", "micanasta_id", c => c.Int());
            CreateIndex("dbo.Refrigeradores", "modeloId");
            CreateIndex("dbo.Refrigeradores", "micanasta_id");
            AddForeignKey("dbo.Refrigeradores", "micanasta_id", "dbo.CanastasBasicas", "id");
            AddForeignKey("dbo.Refrigeradores", "modeloId", "dbo.Modelos", "id", cascadeDelete: true);
            DropColumn("dbo.Refrigeradores", "capacidad");
            DropColumn("dbo.Refrigeradores", "indiceDeEnfriamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Refrigeradores", "indiceDeEnfriamento", c => c.Int(nullable: false));
            AddColumn("dbo.Refrigeradores", "capacidad", c => c.Int(nullable: false));
            DropForeignKey("dbo.Refrigeradores", "modeloId", "dbo.Modelos");
            DropForeignKey("dbo.Refrigeradores", "micanasta_id", "dbo.CanastasBasicas");
            DropIndex("dbo.Refrigeradores", new[] { "micanasta_id" });
            DropIndex("dbo.Refrigeradores", new[] { "modeloId" });
            DropColumn("dbo.Refrigeradores", "micanasta_id");
            DropColumn("dbo.Refrigeradores", "modeloId");
        }
    }
}
