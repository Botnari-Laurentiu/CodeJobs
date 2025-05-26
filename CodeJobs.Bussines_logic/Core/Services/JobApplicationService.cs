using System.Threading.Tasks;
using CodeJobs.Domain.Entities;
using CodeJobs.Domain.Interfaces;

namespace CodeJobs.Business_Logic.Core.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public JobApplicationService(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<JobApplication> ApplyForJob(JobApplication jobApplication)
        {
            return await _jobApplicationRepository.AddApplication(jobApplication);
        }

        public async Task<JobApplication> GetApplicationStatus(int applicationId)
        {
            return await _jobApplicationRepository.GetApplicationById(applicationId);
        }
    }
}