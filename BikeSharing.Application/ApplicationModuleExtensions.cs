﻿using BikeSharing.Application.Services;
using BikeSharing.Application.Services.IServices;
using BikeSharing.Infrastructure;
using BikeSharing.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeSharing.Application
{
    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IBicycleService, BicycleService>();

            services.AddInfrastructureModule(configuration);

            return services;
        }
    }
}
