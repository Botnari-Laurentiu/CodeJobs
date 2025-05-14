using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeJobs.Models
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

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Role)
                .HasColumnType("int");
        }
    }
}
