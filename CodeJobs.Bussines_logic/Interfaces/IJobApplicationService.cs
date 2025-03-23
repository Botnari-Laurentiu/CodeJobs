﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJobs.Bussines_Logic.Interfaces
{
    public interface IJobApplicationService
    {
        Task<JobApplication> ApplyForJob(JobApplication jobApplication);
        Task<JobApplication> GetApplicationStatus(int applicationId);
    }
}
