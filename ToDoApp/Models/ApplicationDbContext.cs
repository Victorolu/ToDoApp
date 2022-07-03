using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<ToDoEntry> toDoEntries) : base(options)
        {
            ToDoEntries = toDoEntries;
        }

        public DbSet<ToDoEntry> ToDoEntries { get; set; }
    }
}
