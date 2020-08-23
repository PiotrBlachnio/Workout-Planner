using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using WorkoutPlanner.Database;
using WorkoutPlanner.Services;

namespace WorkoutPlanner.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));
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
            services.AddScoped<IRoutineService, RoutineService>();
            services.AddScoped<IExerciseService, ExerciseService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services) {
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Workout Planner",
                    Version = "v1"
                });
            });
        }
    }
}