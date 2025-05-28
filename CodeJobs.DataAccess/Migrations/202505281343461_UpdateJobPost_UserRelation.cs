namespace CodeJobs.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobPost_UserRelation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobPosts", name: "EmployerId", newName: "UserId");
            RenameIndex(table: "dbo.JobPosts", name: "IX_EmployerId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobPosts", name: "IX_UserId", newName: "IX_EmployerId");
            RenameColumn(table: "dbo.JobPosts", name: "UserId", newName: "EmployerId");
        }
    }
}
