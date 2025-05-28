using System.Collections.Generic;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Business_Logic.Interfaces
{
    public interface IJobPostRepository
    {
        Task<JobPost> AddJobPost(JobPost jobPost);
        Task<List<JobPost>> GetAllJobPosts();
        Task<JobPost> GetJobPostById(int jobId);
        Task<List<JobPost>> GetJobPostsByUserId(string userId);

    }
}