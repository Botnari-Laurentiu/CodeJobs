using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.DataAccess.Data;
using CodeJobs.Domain.Entities;
using System.Linq;


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

        public async Task<List<JobPost>> GetJobPostsByUserId(string userId)
        {
            return await _context.JobPosts
                .Where(j => j.UserId == userId)
                .ToListAsync();
        }


        public async Task<JobPost> UpdateJobPost(JobPost jobPost)
        {
            var existing = await _context.JobPosts.FindAsync(jobPost.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(jobPost);
                await _context.SaveChangesAsync();
                return existing;
            }
            return null;
        }


        public async Task DeleteJobPost(int jobId)
        {
            var jobPost = await _context.JobPosts.FindAsync(jobId);
            if (jobPost != null)
            {
                _context.JobPosts.Remove(jobPost);
                await _context.SaveChangesAsync();
            }
        }
    }
}