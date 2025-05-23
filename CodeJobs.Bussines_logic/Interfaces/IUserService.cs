using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.Business_Logic.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> AuthenticateUser(string username, string password);
        Task<ApplicationUser> RegisterUser(ApplicationUser user);
        Task<ApplicationUser> GetUserById(string userId);
    }
}
