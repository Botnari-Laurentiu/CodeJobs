using CodeJobs.Business_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJobs.Domain.Entities.User;
using CodeJobs.Models;

namespace CodeJobs.Business_Logic.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> AuthenticateUser(string username, string password)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            await _userRepository.AddUser(user);
            return user;
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userRepository.GetUserById(userId);
        }
    }

    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByUsername(string username);
        Task AddUser(ApplicationUser user);
        Task<ApplicationUser> GetUserById(string userId);
    }
}