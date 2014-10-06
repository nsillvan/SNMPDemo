namespace SNMPDemo.Migrations.SNMPDemoContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcontrols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Device", "showBasicControls", c => c.Boolean(nullable: false));
            AddColumn("dbo.Device", "showPreHeaterTimer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Device", "showPreHeaterTimer");
            DropColumn("dbo.Device", "showBasicControls");
        }
    }
}
