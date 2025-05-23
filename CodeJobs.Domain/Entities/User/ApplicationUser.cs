using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using CodeJobs.Domain.Enums;

namespace CodeJobs.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public UserRole Role { get; set; }

        public ApplicationUser()
        {
            Role = UserRole.User;
        }
    }
}