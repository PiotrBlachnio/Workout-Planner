using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using NotesAPI.Database;
using NotesAPI.Services;

namespace NotesAPI.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("NotesAPIConnection")));
        }

        public static void ConfigureAutoMapper(this IServiceCollection services) {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void ConfigureControllers(this IServiceCollection services) {
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }
        
        public static void AddServices(this IServiceCollection services) {
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}