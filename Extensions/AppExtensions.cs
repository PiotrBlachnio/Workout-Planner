using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkoutPlanner.Settings;

namespace WorkoutPlanner.Extensions {
    public static class AppExtensions {
        public static void ConfigureSwaggerUI(this IApplicationBuilder app, IConfiguration configuration) {
            var swaggerSettings = new SwaggerSettings();
            configuration.GetSection(nameof(SwaggerSettings)).Bind(swaggerSettings);
            
            app.UseSwagger(setting => { setting.RouteTemplate = swaggerSettings.JsonRoute; });
                
            app.UseSwaggerUI(setting => {
                setting.SwaggerEndpoint(swaggerSettings.UIEndpoint, swaggerSettings.Description);
            });
        }
    }
}