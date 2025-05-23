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

        public DateTime PostedDate { get; set; }

        public string EmployerId { get; set; }
        public virtual ApplicationUser Employer { get; set; }

        public JobPost()
        {
            PostedDate = DateTime.Now;
        }
    }
}