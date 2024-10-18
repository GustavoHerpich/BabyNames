using BabyName.Repositories;
using BabyName.Repositories.Impl;
using BabyName.Services;
using BabyName.Services.Impl;

namespace BabyName.Installers;

public static class DependencyInstaller
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBabyNameRepository, BabyNameRepository>();
        services.AddScoped<IBabyNameService, BabyNameService>();
    }
}