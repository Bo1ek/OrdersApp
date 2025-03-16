using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrdersApp.Application.Models;

namespace OrdersApp.Application.Data;

public sealed class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(o => o.orderId);
    }
    public DbSet<Order> Orders { get; set; }
}