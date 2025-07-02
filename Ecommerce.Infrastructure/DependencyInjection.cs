using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Infrastructure.Repositories;
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

            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}
