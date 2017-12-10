namespace JobInn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        blog_id = c.Int(nullable: false, identity: true),
                        blog_title = c.String(maxLength: 100),
                        blog_maintext = c.String(storeType: "ntext"),
                        blog_alerttext = c.String(maxLength: 4000),
                        blog_smallhead = c.String(maxLength: 100),
                        blog_smalltext = c.String(storeType: "ntext"),
                        blog_img = c.String(maxLength: 4000),
                        blog_datetime = c.DateTime(nullable: false),
                        company_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.blog_id)
                .ForeignKey("dbo.Companies", t => t.company_id, cascadeDelete: true)
                .Index(t => t.company_id);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        blogcomment_id = c.Int(nullable: false, identity: true),
                        user_name = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        comment_text = c.String(storeType: "ntext"),
                        blog_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.blogcomment_id)
                .ForeignKey("dbo.Blogs", t => t.blog_id, cascadeDelete: true)
                .Index(t => t.blog_id);
            
            CreateTable(
                "dbo.CommentReplies",
                c => new
                    {
                        commentreply_id = c.Int(nullable: false, identity: true),
                        user_name = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        comment_text = c.String(storeType: "ntext"),
                        blogcomment_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.commentreply_id)
                .ForeignKey("dbo.BlogComments", t => t.blogcomment_id, cascadeDelete: true)
                .Index(t => t.blogcomment_id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        company_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(maxLength: 80),
                        tagline = c.String(maxLength: 4000),
                        description = c.String(storeType: "ntext"),
                        video_link = c.String(maxLength: 4000),
                        web_site = c.String(maxLength: 4000),
                        facebook_link = c.String(maxLength: 4000),
                        googleplus_link = c.String(maxLength: 4000),
                        twitter_link = c.String(maxLength: 4000),
                        linkedin_link = c.String(maxLength: 4000),
                        youtube_link = c.String(maxLength: 4000),
                        logo_img = c.String(maxLength: 4000),
                        user_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.company_id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        job_id = c.Int(nullable: false, identity: true),
                        concerperson_name = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        job_title = c.String(maxLength: 4000),
                        location = c.String(maxLength: 4000),
                        city_id = c.Int(nullable: false),
                        jobcategory_id = c.Int(nullable: false),
                        salary_package = c.String(maxLength: 50),
                        jobtype_id = c.Int(nullable: false),
                        clossing_date = c.DateTime(nullable: false),
                        company_id = c.Int(),
                        user_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.job_id)
                .ForeignKey("dbo.Cities", t => t.city_id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.company_id)
                .ForeignKey("dbo.JobCategories", t => t.jobcategory_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.user_id)
                .ForeignKey("dbo.JobTypes", t => t.jobtype_id, cascadeDelete: true)
                .Index(t => t.city_id)
                .Index(t => t.jobcategory_id)
                .Index(t => t.jobtype_id)
                .Index(t => t.company_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        city_id = c.Int(nullable: false, identity: true),
                        city_name = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.city_id);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        jobcategory_id = c.Int(nullable: false, identity: true),
                        jobcategory_name = c.String(maxLength: 80),
                        jobcategory_img = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.jobcategory_id);
            
            CreateTable(
                "dbo.Jobseekers",
                c => new
                    {
                        jobseekers_id = c.Int(nullable: false, identity: true),
                        full_name = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        professional_title = c.String(maxLength: 4000),
                        category_id = c.Int(nullable: false),
                        min_rate = c.String(maxLength: 80),
                        your_img = c.String(maxLength: 4000),
                        description = c.String(storeType: "ntext"),
                        file = c.String(storeType: "ntext"),
                        url_id = c.Int(nullable: false),
                        education_id = c.Int(nullable: false),
                        experince_id = c.Int(nullable: false),
                        user_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.jobseekers_id)
                .ForeignKey("dbo.Educations", t => t.education_id, cascadeDelete: true)
                .ForeignKey("dbo.Experinces", t => t.experince_id, cascadeDelete: true)
                .ForeignKey("dbo.JobCategories", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.Urls", t => t.url_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.user_id)
                .Index(t => t.category_id)
                .Index(t => t.url_id)
                .Index(t => t.education_id)
                .Index(t => t.experince_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        education_id = c.Int(nullable: false, identity: true),
                        school_name = c.String(maxLength: 100),
                        startent_date = c.String(maxLength: 50),
                        description = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.education_id);
            
            CreateTable(
                "dbo.Experinces",
                c => new
                    {
                        experince_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(maxLength: 80),
                        startend_date = c.String(maxLength: 80),
                        description = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.experince_id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        skill_id = c.Int(nullable: false, identity: true),
                        skill_name = c.String(maxLength: 50),
                        skill_degree = c.Int(nullable: false),
                        jobseeker_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.skill_id)
                .ForeignKey("dbo.Jobseekers", t => t.jobseeker_id, cascadeDelete: true)
                .Index(t => t.jobseeker_id);
            
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        url_id = c.Int(nullable: false, identity: true),
                        url_name = c.String(maxLength: 50),
                        url_link = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.url_id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        first_name = c.String(maxLength: 20),
                        last_name = c.String(maxLength: 20),
                        profil_img = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        jobtype_id = c.Int(nullable: false, identity: true),
                        jobtype_name = c.String(maxLength: 30),
                        jobcolor_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.jobtype_id)
                .ForeignKey("dbo.JobTypeColors", t => t.jobcolor_id, cascadeDelete: true)
                .Index(t => t.jobcolor_id);
            
            CreateTable(
                "dbo.JobTypeColors",
                c => new
                    {
                        typecolor_id = c.Int(nullable: false, identity: true),
                        color_name = c.String(maxLength: 20),
                        color_class = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.typecolor_id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        contact_id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                        email = c.String(maxLength: 100),
                        subject = c.String(maxLength: 4000),
                        comment = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.contact_id);
            
            CreateTable(
                "dbo.PrivacyPolicies",
                c => new
                    {
                        pp_id = c.Int(nullable: false, identity: true),
                        pp_title = c.String(maxLength: 4000),
                        pp_text = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.pp_id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Companies", "user_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobTypes", "jobcolor_id", "dbo.JobTypeColors");
            DropForeignKey("dbo.Jobs", "jobtype_id", "dbo.JobTypes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobseekers", "user_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "user_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobseekers", "url_id", "dbo.Urls");
            DropForeignKey("dbo.Skills", "jobseeker_id", "dbo.Jobseekers");
            DropForeignKey("dbo.Jobseekers", "category_id", "dbo.JobCategories");
            DropForeignKey("dbo.Jobseekers", "experince_id", "dbo.Experinces");
            DropForeignKey("dbo.Jobseekers", "education_id", "dbo.Educations");
            DropForeignKey("dbo.Jobs", "jobcategory_id", "dbo.JobCategories");
            DropForeignKey("dbo.Jobs", "company_id", "dbo.Companies");
            DropForeignKey("dbo.Jobs", "city_id", "dbo.Cities");
            DropForeignKey("dbo.Blogs", "company_id", "dbo.Companies");
            DropForeignKey("dbo.CommentReplies", "blogcomment_id", "dbo.BlogComments");
            DropForeignKey("dbo.BlogComments", "blog_id", "dbo.Blogs");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.JobTypes", new[] { "jobcolor_id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Skills", new[] { "jobseeker_id" });
            DropIndex("dbo.Jobseekers", new[] { "user_id" });
            DropIndex("dbo.Jobseekers", new[] { "experince_id" });
            DropIndex("dbo.Jobseekers", new[] { "education_id" });
            DropIndex("dbo.Jobseekers", new[] { "url_id" });
            DropIndex("dbo.Jobseekers", new[] { "category_id" });
            DropIndex("dbo.Jobs", new[] { "user_id" });
            DropIndex("dbo.Jobs", new[] { "company_id" });
            DropIndex("dbo.Jobs", new[] { "jobtype_id" });
            DropIndex("dbo.Jobs", new[] { "jobcategory_id" });
            DropIndex("dbo.Jobs", new[] { "city_id" });
            DropIndex("dbo.Companies", new[] { "user_id" });
            DropIndex("dbo.CommentReplies", new[] { "blogcomment_id" });
            DropIndex("dbo.BlogComments", new[] { "blog_id" });
            DropIndex("dbo.Blogs", new[] { "company_id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PrivacyPolicies");
            DropTable("dbo.Contacts");
            DropTable("dbo.JobTypeColors");
            DropTable("dbo.JobTypes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Urls");
            DropTable("dbo.Skills");
            DropTable("dbo.Experinces");
            DropTable("dbo.Educations");
            DropTable("dbo.Jobseekers");
            DropTable("dbo.JobCategories");
            DropTable("dbo.Cities");
            DropTable("dbo.Jobs");
            DropTable("dbo.Companies");
            DropTable("dbo.CommentReplies");
            DropTable("dbo.BlogComments");
            DropTable("dbo.Blogs");
        }
    }
}
