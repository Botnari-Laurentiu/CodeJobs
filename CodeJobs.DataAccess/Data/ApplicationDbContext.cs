using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeJobs.Domain.Entities.User;
using CodeJobs.Domain.Entities;

namespace CodeJobs.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("name=CodeJobsConnection") { }
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