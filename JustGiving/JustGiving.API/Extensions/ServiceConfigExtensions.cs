﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace JustGiving.API.Extensions
{
    public static class ServiceConfigExtensions
    {
        public static IServiceCollection AddSystemServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Just Giving API",
                    Version = "v1",
                    Description = "Gift Aid Service",
                    Contact = new OpenApiContact
                    {
                        Name = "Chad Bonthuys",
                        Email = "chad@atomixdev.com",
                        Url = new Uri("https://www.linkedin.com/in/chadbonthuys/"),
                    },
                });
            });

            return services;
        }
    }
}