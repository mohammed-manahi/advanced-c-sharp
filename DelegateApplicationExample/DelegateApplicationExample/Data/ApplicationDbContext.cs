using DelegateApplicationExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DelegateApplicationExample.Data;

public class ApplicationDbContext : DbContext
{
    // Inherits the base DbContext class of EF Core
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure EF Core and Sqlite database
        optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}DelegateApplicationExampleDb.db");
        base.OnConfiguring(optionsBuilder);
    }
    
    // Generic DbSet takes the model class name to generate a table with property name 'Users'
    public DbSet<User> Users { get; set; }
}