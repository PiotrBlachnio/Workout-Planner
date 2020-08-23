using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkoutPlanner.Database {
    public static class PrepareDatabase {
        public static void PrepPopulation(IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices.CreateScope()) {
                ApplyMigrations(serviceScope.ServiceProvider.GetService<DatabaseContext>());
            }
        }

        private static void ApplyMigrations(DatabaseContext context) {
            Console.WriteLine("Applying migrations...");
            context.Database.Migrate();
        }
    }
}