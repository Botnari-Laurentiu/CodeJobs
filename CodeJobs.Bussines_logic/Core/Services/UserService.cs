using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CodeJobs.DataAccess;
using CodeJobs.Domain.Entities.User;
using CodeJobs.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeJobs.Business_Logic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            _userManager = new UserManager<ApplicationUser>(userStore);
        }

        public async Task<ApplicationUser> AuthenticateUser(string username, string password)
        {
            // Găsește userul după username
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
                return user;
            return null;
        }

        public Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> RegisterUser(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded ? user : null;
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}