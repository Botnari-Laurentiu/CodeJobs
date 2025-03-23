using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace CodeJobs.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } 

        [StringLength(200)]
        public string CompanyName { get; set; } 

        [StringLength(500)]
        public string Resume { get; set; } 

        public UserRole Role { get; set; } 

      
        public ApplicationUser()
        {
            Role = UserRole.JobSeeker; 
        }
    }

    public enum UserRole
    {
        Admin,
        Employer,
        JobSeeker
    }
}
