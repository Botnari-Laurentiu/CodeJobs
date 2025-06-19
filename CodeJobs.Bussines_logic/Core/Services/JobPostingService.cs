using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Business_Logic.Repositories;
using CodeJobs.Domain.Entities;

public class JobPostingService : IJobPostService
{
    private readonly IJobPostRepository _jobPostRepository;

    public JobPostingService(IJobPostRepository repository)
    {
        _jobPostRepository = repository;
    }

    public JobPostingService()
    {
        _jobPostRepository = new JobPostRepository();
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

    // AICI trebuie să pui metodele:
    public async Task<List<JobPost>> GetJobPostsByUserId(string userId)
    {
        return await _jobPostRepository.GetJobPostsByUserId(userId);
    }

    public async Task<JobPost> UpdateJobPost(JobPost jobPost)
    {
        return await _jobPostRepository.UpdateJobPost(jobPost);
    }

    public async Task DeleteJobPost(int jobId)
    {
        await _jobPostRepository.DeleteJobPost(jobId);
    }

    public async Task<List<JobPost>> SearchJobPosts(string query)
    {
        var allJobs = await _jobPostRepository.GetAllJobPosts();
        return allJobs
            .Where(j => (j.Title != null && j.Title.ToLower().Contains(query.ToLower()))
                        || (j.Description != null && j.Description.ToLower().Contains(query.ToLower())))
            .ToList();
    }
}