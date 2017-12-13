namespace JobInn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetimenow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "blog_datetime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "blog_datetime");
        }
    }
}
