using Microsoft.EntityFrameworkCore;
using OrdersApp.Application.Models;

namespace OrdersApp.Application.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
    }
    public DbSet<Order> Orders { get; set; }
}