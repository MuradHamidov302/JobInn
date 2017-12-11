namespace JobInn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkdatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobseekers", "location", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobseekers", "location");
        }
    }
}
