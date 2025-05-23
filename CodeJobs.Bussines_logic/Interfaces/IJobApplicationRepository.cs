using System.Threading.Tasks;
using CodeJobs.Domain.Entities;

namespace CodeJobs.Bussines_Logic.Interfaces
{
    public interface IJobApplicationRepository
    {
        Task<JobApplication> AddApplication(JobApplication jobApplication);
        Task<JobApplication> GetApplicationById(int applicationId);
    }
}
