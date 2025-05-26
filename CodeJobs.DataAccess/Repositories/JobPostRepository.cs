using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities;
using CodeJobs.DataAccess;
using CodeJobs.Domain.Interfaces;

namespace CodeJobs.Business_Logic.Core.Services
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly ApplicationDbContext _context;

        public JobPostRepository()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<JobPost> AddJobPost(JobPost jobPost)
        {
            _context.JobPosts.Add(jobPost);
            await _context.SaveChangesAsync();
            return jobPost;
        }

        public async Task<List<JobPost>> GetAllJobPosts()
        {
            return await _context.JobPosts.ToListAsync();
        }

        public async Task<JobPost> GetJobPostById(int jobId)
        {
            return await _context.JobPosts.FindAsync(jobId);
        }
    }
}