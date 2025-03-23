using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeJobs.Models
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
        public DateTime AppliedDate { get; set; } = DateTime.Now;

        [StringLength(1000)]
        public string CoverLetter { get; set; }
    }
}