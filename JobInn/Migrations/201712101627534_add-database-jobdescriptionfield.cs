namespace JobInn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatabasejobdescriptionfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "description");
        }
    }
}
