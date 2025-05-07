using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace CodeJobs.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Id { get; set; } // Primary key
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; } // Store hashed passwords
        public UserRole Role { get; set; } // Enum for roles (Admin, Employer, JobSeeker)



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
