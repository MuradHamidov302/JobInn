namespace JobInn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobseeker_table_jobtypeid_field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobseekers", "jobtype_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobseekers", "jobtype_id");
            AddForeignKey("dbo.Jobseekers", "jobtype_id", "dbo.JobTypes", "jobtype_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobseekers", "jobtype_id", "dbo.JobTypes");
            DropIndex("dbo.Jobseekers", new[] { "jobtype_id" });
            DropColumn("dbo.Jobseekers", "jobtype_id");
        }
    }
}
