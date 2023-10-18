using Microsoft.Extensions.DependencyInjection;
using TDDApplication3.Service.AutomapperProfiles;
using TDDApplication3.Service.Interface;

namespace TDDApplication3.Service;

public static class DependencyInjection
{
    public static void RegisterBLLDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddScoped<IUserService, UserService>();
        DataAccessLayer.DependencyInjection.RegisterDALDependencies(services);
    }
}