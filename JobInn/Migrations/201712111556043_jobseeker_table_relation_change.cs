namespace JobInn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobseeker_table_relation_change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobseekers", "education_id", "dbo.Educations");
            DropForeignKey("dbo.Jobseekers", "experince_id", "dbo.Experinces");
            DropForeignKey("dbo.Jobseekers", "url_id", "dbo.Urls");
            DropIndex("dbo.Jobseekers", new[] { "url_id" });
            DropIndex("dbo.Jobseekers", new[] { "education_id" });
            DropIndex("dbo.Jobseekers", new[] { "experince_id" });
            AddColumn("dbo.Educations", "jobseeker_id", c => c.Int(nullable: false));
            AddColumn("dbo.Experinces", "jobseeker_id", c => c.Int(nullable: false));
            AddColumn("dbo.Urls", "jobseeker_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Educations", "jobseeker_id");
            CreateIndex("dbo.Experinces", "jobseeker_id");
            CreateIndex("dbo.Urls", "jobseeker_id");
            AddForeignKey("dbo.Educations", "jobseeker_id", "dbo.Jobseekers", "jobseekers_id", cascadeDelete: true);
            AddForeignKey("dbo.Experinces", "jobseeker_id", "dbo.Jobseekers", "jobseekers_id", cascadeDelete: true);
            AddForeignKey("dbo.Urls", "jobseeker_id", "dbo.Jobseekers", "jobseekers_id", cascadeDelete: true);
            DropColumn("dbo.Jobseekers", "url_id");
            DropColumn("dbo.Jobseekers", "education_id");
            DropColumn("dbo.Jobseekers", "experince_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobseekers", "experince_id", c => c.Int(nullable: false));
            AddColumn("dbo.Jobseekers", "education_id", c => c.Int(nullable: false));
            AddColumn("dbo.Jobseekers", "url_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Urls", "jobseeker_id", "dbo.Jobseekers");
            DropForeignKey("dbo.Experinces", "jobseeker_id", "dbo.Jobseekers");
            DropForeignKey("dbo.Educations", "jobseeker_id", "dbo.Jobseekers");
            DropIndex("dbo.Urls", new[] { "jobseeker_id" });
            DropIndex("dbo.Experinces", new[] { "jobseeker_id" });
            DropIndex("dbo.Educations", new[] { "jobseeker_id" });
            DropColumn("dbo.Urls", "jobseeker_id");
            DropColumn("dbo.Experinces", "jobseeker_id");
            DropColumn("dbo.Educations", "jobseeker_id");
            CreateIndex("dbo.Jobseekers", "experince_id");
            CreateIndex("dbo.Jobseekers", "education_id");
            CreateIndex("dbo.Jobseekers", "url_id");
            AddForeignKey("dbo.Jobseekers", "url_id", "dbo.Urls", "url_id", cascadeDelete: true);
            AddForeignKey("dbo.Jobseekers", "experince_id", "dbo.Experinces", "experince_id", cascadeDelete: true);
            AddForeignKey("dbo.Jobseekers", "education_id", "dbo.Educations", "education_id", cascadeDelete: true);
        }
    }
}
