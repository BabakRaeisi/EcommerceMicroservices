using Ecommerce.Core.ServiceContracts;
using Ecommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
 

namespace Ecommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the dependecy injection container.
        /// 
        ///</summary>
        ///>/// <param name="services">.</param>
        ///<returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // Register your infrastructure services here
            // Example: services.AddSingleton<IMyService, MyService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
