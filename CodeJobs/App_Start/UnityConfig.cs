using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeJobs.Domain.Entities.User;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.DataAccess.Data;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // Register ApplicationDbContext with per-request lifetime
        container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());

        // Register UserStore with explicit constructor injection
        container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
            new InjectionConstructor(typeof(ApplicationDbContext))
        );

        // Register UserManager
        container.RegisterType<UserManager<ApplicationUser>>();

        // Register your UserService
        container.RegisterType<IUserService, UserService>();

        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
}