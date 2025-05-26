using System.Collections.Generic;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Domain.Interfaces
{
    public interface IJobPostRepository
    {
        Task<JobPost> AddJobPost(JobPost jobPost);
        Task<List<JobPost>> GetAllJobPosts();
        Task<JobPost> GetJobPostById(int jobId);
    }
}