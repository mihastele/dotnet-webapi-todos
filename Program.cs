// Add this using statement at the top
using DotnetDemoAPI.Data;
using Microsoft.EntityFrameworkCore;

// In the main Program.cs
var builder = WebApplication.CreateBuilder(args);

// ... existing code ...

// Read the database provider from config
var dbProvider = builder.Configuration["DatabaseProvider"]?.ToLower() ?? "sqlite";  // Default to SQLite

var connectionString = dbProvider switch
{
    "mysql" => builder.Configuration.GetConnectionString("MySqlConnection"),
    _ => builder.Configuration.GetConnectionString("SqliteConnection")
};

builder.Services.AddDbContext<AppDbContext>(options =>
{
    // if (dbProvider == "mysql")
    // {
    //     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    // }

        options.UseSqlite(connectionString);
});

// ... rest of the code ...
var app = builder.Build();

// Optional: Configure middleware
app.UseRouting();
app.UseAuthorization(); // If you're using authentication

// Map your controllers
app.MapControllers();

// Run the app
app.Run();
