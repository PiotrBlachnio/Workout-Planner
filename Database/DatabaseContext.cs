using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Database.Models;

namespace WorkoutPlanner.Database {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}