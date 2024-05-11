using Microsoft.EntityFrameworkCore;

namespace ConsoleTodoList;

public class TodoContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Environment.GetEnvironmentVariable("CONSOLE_TODO_DB_CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connectionString);
    }
}