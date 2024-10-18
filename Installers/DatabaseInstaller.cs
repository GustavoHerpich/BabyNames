﻿using BabyName.Data;
using Microsoft.EntityFrameworkCore;

namespace BabyName.Installers;

public static class DatabaseInstaller
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkSqlServer()
            .AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DataBase"),
                sqlOptions => sqlOptions.EnableRetryOnFailure())
            );

        return services;
    }
}