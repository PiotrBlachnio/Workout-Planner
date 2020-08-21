using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Database {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) {}

        public DbSet<Routine> Routines { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}