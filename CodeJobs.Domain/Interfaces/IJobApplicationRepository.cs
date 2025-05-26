using System.Threading.Tasks;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Domain.Interfaces
{
    public interface IJobApplicationRepository
    {
        Task<JobApplication> AddApplication(JobApplication jobApplication);
        Task<JobApplication> GetApplicationById(int applicationId);
    }
}
