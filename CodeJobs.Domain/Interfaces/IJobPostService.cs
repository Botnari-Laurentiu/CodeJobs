using System.Collections.Generic;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Domain.Interfaces
{
    public interface IJobPostService
    {
        Task<JobPost> CreateJobPost(JobPost jobPost);
        Task<List<JobPost>> GetAllJobPosts();
        Task<JobPost> GetJobPostById(int jobId);
    }
}