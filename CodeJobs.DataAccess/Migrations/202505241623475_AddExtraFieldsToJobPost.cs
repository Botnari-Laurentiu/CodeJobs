namespace CodeJobs.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExtraFieldsToJobPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "RequiredSkills", c => c.String(nullable: false));
            AddColumn("dbo.JobPosts", "ExperienceLevel", c => c.String(nullable: false));
            AddColumn("dbo.JobPosts", "EmploymentType", c => c.String(nullable: false));
            AddColumn("dbo.JobPosts", "Location", c => c.String());
            AddColumn("dbo.JobPosts", "SalaryRange", c => c.String());
            AddColumn("dbo.JobPosts", "ContactEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "ContactEmail");
            DropColumn("dbo.JobPosts", "SalaryRange");
            DropColumn("dbo.JobPosts", "Location");
            DropColumn("dbo.JobPosts", "EmploymentType");
            DropColumn("dbo.JobPosts", "ExperienceLevel");
            DropColumn("dbo.JobPosts", "RequiredSkills");
        }
    }
}
