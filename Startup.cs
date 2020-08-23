using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WorkoutPlanner.Extensions;
using WorkoutPlanner.Middlewares;
using WorkoutPlanner.Settings;

namespace WorkoutPlanner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDatabase(Configuration);

            services.ConfigureAutoMapper();

            services.ConfigureControllers();

            services.AddServices();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Workout Planner",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            var swaggerSettings = new SwaggerSettings();
            Configuration.GetSection(nameof(SwaggerSettings)).Bind(swaggerSettings);
            
            app.UseSwagger(setting => { setting.RouteTemplate = swaggerSettings.JsonRoute; });
                
            app.UseSwaggerUI(setting => {
                setting.SwaggerEndpoint(swaggerSettings.UIEndpoint, swaggerSettings.Description);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use((context, next) => {
                context.Request.EnableBuffering();
                return next();
            });
        }
    }
}