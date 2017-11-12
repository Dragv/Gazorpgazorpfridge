namespace Gazorpgazorpfridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refri_model_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Refrigeradores", "capacidad_restante", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Refrigeradores", "capacidad_restante");
        }
    }
}
