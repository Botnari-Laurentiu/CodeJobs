using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.Business_Logic.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> AuthenticateUser(string email, string password);
        Task<IdentityResult> RegisterUser(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserById(string userId);
        Task<List<ApplicationUser>> GetAllUsers();
        Task UpdateUser(ApplicationUser user);
        Task SaveChangesAsync();
        Task DeleteUserAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}