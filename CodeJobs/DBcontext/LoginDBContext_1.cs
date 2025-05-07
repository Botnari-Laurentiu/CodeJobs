using System.Data.Entity;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.DBcontext
{
    public class LoginDBContext_1 : DbContext
    {
        public LoginDBContext_1() : base("CodeJobsConnection") { }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
