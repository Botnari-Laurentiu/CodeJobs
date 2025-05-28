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


        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Phone]
        public override string PhoneNumber { get; set; } 
        public string Bio { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }

        public string Skills { get; set; }

        public int? ExperienceYears { get; set; }

        [StringLength(50)]
        public string EmploymentType { get; set; }

        [StringLength(100)]
        public string PreferredLocation { get; set; }

        [Url]
        public string LinkedInProfile { get; set; }

        public ApplicationUser()
        {
            Role = UserRole.User;
        }
    }
}