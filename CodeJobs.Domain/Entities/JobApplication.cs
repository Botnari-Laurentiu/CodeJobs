using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.Domain.Entities
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int JobPostId { get; set; }

        [ForeignKey("JobPostId")]
        public virtual JobPost JobPost { get; set; }

        [Required]
        public string ApplicantId { get; set; }

        [ForeignKey("ApplicantId")]
        public virtual ApplicationUser Applicant { get; set; }

        [Required]
        public DateTime AppliedDate { get; set; }

        [StringLength(1000)]
        public string CoverLetter { get; set; }

        public JobApplication()
        {
            AppliedDate = DateTime.Now;
        }
    }
}