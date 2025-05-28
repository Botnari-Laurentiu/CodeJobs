namespace CodeJobs.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserExtendedFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Bio", c => c.String());
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Skills", c => c.String());
            AddColumn("dbo.AspNetUsers", "ExperienceYears", c => c.Int());
            AddColumn("dbo.AspNetUsers", "EmploymentType", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "PreferredLocation", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "LinkedInProfile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LinkedInProfile");
            DropColumn("dbo.AspNetUsers", "PreferredLocation");
            DropColumn("dbo.AspNetUsers", "EmploymentType");
            DropColumn("dbo.AspNetUsers", "ExperienceYears");
            DropColumn("dbo.AspNetUsers", "Skills");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "Bio");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
