using JG.FinTechTest.Data;
using JG.FinTechTest.Data.Repository;
using JG.FinTechTest.Data.Services;
using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace JG.FinTechTest.API.Extensions
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

            services.AddScoped<EFRepository>();
            services.AddScoped<RepositoryService>();
            services.AddScoped<IGiftAidService, GiftAidCalculatorService>();
            services.AddScoped<IDonationService, DonationService>();
            services.AddEntityFrameworkSqlite().AddDbContext<JGDBContext>();

            return services;
        }
    }
}