using Microsoft.Extensions.DependencyInjection;
using TDDApplication3.DataAccessLayer.Interface;

namespace TDDApplication3.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
