namespace JobInn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_field_jobtypecolor_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTypeColors", "colorDetail_class", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobTypeColors", "colorDetail_class");
        }
    }
}
