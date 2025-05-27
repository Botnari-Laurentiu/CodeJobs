using System.Collections.Generic;
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
}
