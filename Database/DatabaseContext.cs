using Microsoft.EntityFrameworkCore;
using NotesAPI.Database.Models;

namespace NotesAPI.Database {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) {}

        public DbSet<Category> Categories { get; set; }
    }
}