using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Models;

namespace CodeJobs.Business_Logic.Core.Services
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostService(IJobPostRepository jobPostRepository)
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

    public interface IJobPostRepository
    {
        Task<JobPost> AddJobPost(JobPost jobPost);
        Task<List<JobPost>> GetAllJobPosts();
        Task<JobPost> GetJobPostById(int jobId);
    }
}

