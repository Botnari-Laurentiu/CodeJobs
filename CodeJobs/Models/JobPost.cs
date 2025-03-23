using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeJobs.Models
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

        public DateTime PostedDate { get; set; } = DateTime.Now;

        public string EmployerId { get; set; }
        public virtual ApplicationUser Employer { get; set; }
    }
}