using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.DataAccess.Data;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Business_Logic.Repositories
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