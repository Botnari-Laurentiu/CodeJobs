using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Domain.Entities.User;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUser(ApplicationUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<ApplicationUser> AuthenticateUser(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null && await _userManager.CheckPasswordAsync(user, password))
            return user;
        return null;
    }


    public async Task<ApplicationUser> GetUserById(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<List<ApplicationUser>> GetAllUsers()
    {
        var users = _userManager.Users;
        return await Task.FromResult(new List<ApplicationUser>(users));
    }

    public async Task UpdateUser(ApplicationUser user)
    {
        await _userManager.UpdateAsync(user);
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
    public async Task DeleteUserAsync(ApplicationUser user)
    {
        await _userManager.DeleteAsync(user);
    }

}