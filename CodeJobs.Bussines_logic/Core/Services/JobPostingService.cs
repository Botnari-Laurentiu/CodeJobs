using System.Collections.Generic;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;
using CodeJobs.Domain.Interfaces;

namespace CodeJobs.Business_Logic.Core.Services
{
    public class JobPostingService : IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostingService(IJobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
        }

        public async Task<JobPost> CreateJobPost(JobPost jobPost)
        {
            return await _jobPostRepository.AddJobPost(jobPost);
        }

        public async Task<List<JobPost>> GetAllJobPosts()
        {
            return await _jobPostRepository.GetAllJobPosts();
        }

        public async Task<JobPost> GetJobPostById(int jobId)
        {
            return await _jobPostRepository.GetJobPostById(jobId);
        }
    }
}