namespace SNMPDemo.Migrations.SNMPDemoContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Device", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Device", "Description");
        }
    }
}
