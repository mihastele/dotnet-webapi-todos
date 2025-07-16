using Microsoft.EntityFrameworkCore;
using DotnetDemoAPI.Models;

namespace DotnetDemoAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlite("Data Source=app.db"); // Or MySQL, SQL Server, etc.
    }
}
}
