using System.Data.Entity;
using CodeJobs.Domain.Entities;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=CodeJobsConnection") { }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobApplication>()
                .HasRequired(ja => ja.Applicant)
                .WithMany()
                .HasForeignKey(ja => ja.ApplicantId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobApplication>()
                .HasRequired(ja => ja.JobPost)
                .WithMany()
                .HasForeignKey(ja => ja.JobPostId)
                .WillCascadeOnDelete(false);
        }
    }
}
