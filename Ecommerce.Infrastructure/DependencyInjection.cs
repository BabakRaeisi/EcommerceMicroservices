using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Core.ServiceContracts;
using Ecommerce.Infrastructure.DbContext;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
 

namespace Ecommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the dependecy injection container.
        /// 
        ///</summary>
        ///>/// <param name="services">.</param>
        ///<returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register your infrastructure services here
            // Example: services.AddSingleton<IMyService, MyService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();

            // Add this line to register TokenService
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
