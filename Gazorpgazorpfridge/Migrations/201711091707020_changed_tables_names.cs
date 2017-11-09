namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_tables_names : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CanastaBasicas", newName: "CanastasBasicas");
            RenameTable(name: "dbo.Productoes", newName: "Productos");
            RenameTable(name: "dbo.Modeloes", newName: "Modelos");
            RenameTable(name: "dbo.Refrigeradors", newName: "Refrigeradores");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Refrigeradores", newName: "Refrigeradors");
            RenameTable(name: "dbo.Modelos", newName: "Modeloes");
            RenameTable(name: "dbo.Productos", newName: "Productoes");
            RenameTable(name: "dbo.CanastasBasicas", newName: "CanastaBasicas");
        }
    }
}
