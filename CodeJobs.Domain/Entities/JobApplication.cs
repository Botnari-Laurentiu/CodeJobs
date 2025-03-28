﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJobs.Domain.Enums;

namespace CodeJobs.Domain.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int JobPostId { get; set; }
        public string ApplicantId { get; set; }
        public string CoverLetter { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
