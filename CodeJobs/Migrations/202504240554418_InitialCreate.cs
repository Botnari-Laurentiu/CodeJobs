namespace CodeJobs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobPostId = c.Int(nullable: false),
                        ApplicantId = c.String(nullable: false, maxLength: 128),
                        CoverLetter = c.String(),
                        Status = c.Int(nullable: false),
                        JobPost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicantId)
                .ForeignKey("dbo.JobPosts", t => t.JobPost_Id)
                .ForeignKey("dbo.JobPosts", t => t.JobPostId)
                .Index(t => t.JobPostId)
                .Index(t => t.ApplicantId)
                .Index(t => t.JobPost_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CompanyName = c.String(),
                        Location = c.String(),
                        EmployerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplications", "JobPostId", "dbo.JobPosts");
            DropForeignKey("dbo.JobApplications", "JobPost_Id", "dbo.JobPosts");
            DropForeignKey("dbo.JobApplications", "ApplicantId", "dbo.ApplicationUsers");
            DropIndex("dbo.JobApplications", new[] { "JobPost_Id" });
            DropIndex("dbo.JobApplications", new[] { "ApplicantId" });
            DropIndex("dbo.JobApplications", new[] { "JobPostId" });
            DropTable("dbo.JobPosts");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.JobApplications");
        }
    }
}
