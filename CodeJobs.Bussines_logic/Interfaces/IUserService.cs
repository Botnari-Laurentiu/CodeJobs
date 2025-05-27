using System.Collections.Generic;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.Business_Logic.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> AuthenticateUser(string username, string password);
        Task<ApplicationUser> RegisterUser(ApplicationUser user);
        Task<ApplicationUser> GetUserById(string userId);

        Task<List<ApplicationUser>> GetAllUsers();
    }
}