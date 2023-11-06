using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Application;
using TaskManagementAPI.Data.Domain;
using TaskManagementAPI.Data.Repositories;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.DI
{
    public static class DependencyInjectionProfile
    {
        public static void RegisterProfile(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DevConnection"))
                    .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });

            #region Services

            services.AddTransient<ICategoryAppService, CategoryAppService>();
            services.AddTransient<ILocationAppService, LocationAppService>();
            services.AddTransient<IUserService, UserAppService>();
            services.AddTransient<IWorkTaskAppService, WorkTaskAppService>();

            #endregion

            #region Repositories

            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ILocationDomainService, LocationDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IWorkTaskDomainService, WorkTaskDomainService>();

            #endregion

        }
    }
}

