using System;
using System.ComponentModel.DataAnnotations;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.Domain.Entities
{
    public class JobPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string RequiredSkills { get; set; }

        [Required]
        public string ExperienceLevel { get; set; }

        [Required]
        public string EmploymentType { get; set; }

        public string Location { get; set; }

        public string SalaryRange { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        public DateTime PostedDate { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public JobPost()
        {
            PostedDate = DateTime.Now;
        }
    }
}