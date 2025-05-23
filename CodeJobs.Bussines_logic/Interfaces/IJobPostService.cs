using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Business_Logic.Interfaces
{
    public interface IJobPostService
    {
        Task<JobPost> CreateJobPost(JobPost jobPost);
        Task<List<JobPost>> GetAllJobPosts();
        Task<JobPost> GetJobPostById(int jobId);
    }
}