using System.Collections.Generic;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Business_Logic.Interfaces
{
    public interface IJobPostService
    {
        Task<JobPost> CreateJobPost(JobPost jobPost);
        Task<List<JobPost>> GetAllJobPosts();
        Task<JobPost> GetJobPostById(int jobId);
        Task<List<JobPost>> GetJobPostsByUserId(string userId);

    }
}